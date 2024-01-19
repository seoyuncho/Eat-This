using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource audiosource_1;    
    public AudioSource audiosource_2;
    public AudioSource goldengooseaudio;
    public AudioSource losesound;
    private Animator animator;
    private GameManager gameManager;
    public float movespeed = 8f;
    public float jumpForce = 300f;
    public DongGenerator donggenerator;
    public CoinGenerator coingenerator;
    public GooseGenerator gooseGenerator;
    private Rigidbody2D rb;
    public GameObject winPanel;
    public GameObject losePanel;
    bool alreadylost = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("IsJumpingLeft", false);
        animator.SetBool("IsJumpingRight", false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        ScreenChk();
    }
    void Move(){
        // 오른쪽 방향키 입력을 감지
        if (Input.GetKey(KeyCode.RightArrow)) {
            animator.SetFloat("RightRun", 1);
            // 오른쪽으로 이동
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }

        // 왼쪽 방향키 입력을 감지
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            animator.SetFloat("LeftRun", 1);
            // 왼쪽으로 이동
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        else {
            animator.SetFloat("LeftRun", 0);
            animator.SetFloat("RightRun", 0);
        }
    }
    void Jump(){
        bool isMovingRight = rb.velocity.x >= 0;
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumpingRight", isMovingRight);
            animator.SetBool("IsJumpingLeft", !isMovingRight);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ddong"){
            if(!gameManager.isToiletActive){
                audiosource_2.Play();
                audiosource_1.mute = true;
                audiosource_2.mute = true;
                if (PlayerPrefs.GetInt("isMultimode", 0) == 0){
                    Destroy(collision.gameObject);
                    FindObjectOfType<GameManager>().GameOver();
                }
                else{
                    if(!alreadylost){
                        losesound.Play();
                        losePanel.SetActive(true);
                        FindObjectOfType<GameManager>().SendLoseMessage();
                        alreadylost= !alreadylost;
                    }
                }
            }
        }
        else if(collision.gameObject.tag =="Coin"){
            audiosource_1.Play();
            Destroy(collision.gameObject);
            GameManager.coin ++;
        }
        else if(collision.gameObject.tag =="RainbowCoin"){
            audiosource_1.Play();
            Destroy(collision.gameObject);
            GameManager.coin +=3;
        }
        else if(collision.gameObject.tag =="goose"){
            goldengooseaudio.Play();
            Destroy(collision.gameObject);
            GameObject[] allDdong = GameObject.FindGameObjectsWithTag("Ddong");
            foreach (GameObject dong in allDdong) {
                Destroy(dong);
            }
            GameObject[] allcoin = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject coin in allcoin) {
                Destroy(coin);
            }
            ActivateGoldenGooseMode();
        }
        else if (collision.gameObject.tag == "Ground") {
            Debug.Log("땅과 닿아있습니다");
            animator.SetBool("IsJumpingRight", false);
            animator.SetBool("IsJumpingLeft", false);
        }
    }
    private void ScreenChk() {
        Vector3 woripos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (woripos.x < 0.05f) woripos.x = 0.05f;
        if (woripos.x > 0.95f) woripos.x = 0.95f;
        this.transform.position = Camera.main.ViewportToWorldPoint(woripos);
    }
    void ActivateGoldenGooseMode(){
        coingenerator.ActivateGoldenGooseMode();
        donggenerator.Deactivate();
        gooseGenerator.Deactivate();
        StartCoroutine(DeactivateGoldenGooseMode());
    }
    IEnumerator DeactivateGoldenGooseMode() {
        yield return new WaitForSeconds(5);
        coingenerator.DeactivateGoldenGooseMode();
        donggenerator.Activate();
        gooseGenerator.Activate();

}

}
