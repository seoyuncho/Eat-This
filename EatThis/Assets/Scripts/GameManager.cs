using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class GameManager : MonoBehaviourPun {
    public AudioSource audiosource;
    public AudioSource backgroundaudio;
    public AudioSource itemsound;
    public AudioSource losesound;
    public AudioSource winsound;
    private float timer = 0.0f;
    public GameObject yellowcircle1, yellowcircle2, yellowcircle3;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject umbrella;
    public GameObject Bbtext;
    private DongGenerator dongGenerator;
    private DongAttackGenerator dongAttackGenerator;
    public GameObject toilet;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI finalscoretext;
    public AnimationCurve movementCurve;
    public static int score = 0;
    public static int coin = 0;
    public bool isToiletActive = false;
    public GameObject fartCloud;
    public GameObject stage1Text, stage2Text, stage3Text;
    private bool isGameOvered = false;
    public static GameManager Instance;
    public int Score;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start() {
        backgroundaudio.Play();
        dongGenerator = FindObjectOfType<DongGenerator>();
        dongAttackGenerator = FindObjectOfType<DongAttackGenerator>();
        dongAttackGenerator.Deactivate();
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        umbrella.SetActive(false);
        Bbtext.SetActive(false);
        toilet.SetActive(false);
        isToiletActive = false;
        stage1Text.SetActive(false);
        stage2Text.SetActive(false);
        stage3Text.SetActive(false);
        yellowcircle1.SetActive(false);
        yellowcircle2.SetActive(false);
        yellowcircle3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOvered){
            timer +=Time.deltaTime;
            if(timer>=3){
                score ++;
                timer = 0.0f;
            }
        }
        scoretext.text = "" + score;
        cointext.text = "" + coin;
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
            if (coin >= 5) {
                itemsound.Play();
                dongGenerator.Deactivate(); // DongGenerator 스크립트의 Deactivate 메서드 호출
                Bbtext.SetActive(true);
                GameObject[] allDdong = GameObject.FindGameObjectsWithTag("Ddong");
                foreach (GameObject dong in allDdong) {
                    Destroy(dong);
                }
                coin -= 5;
                yellowcircle1.SetActive(true);
                StartCoroutine(DeactivateBbAfterTime(5));
            } 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
            if(coin >= 10){
                itemsound.Play();
                coin-=10;
                toilet.SetActive(true);
                ActivateToilet();
                yellowcircle2.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
            if(coin >= 20) {
                itemsound.Play();
                umbrella.SetActive(true);
                coin -= 20;
                StartCoroutine(DeactivateUmbrellaAfterTime(5));
                yellowcircle3.SetActive(true);

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if(coin >= 10) {
                itemsound.Play();
                HandleKeyInput(4);
                coin -= 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            if(coin >= 30) {
                itemsound.Play();            
                //dongGenerator.FiveItemActivate();
                HandleKeyInput(5);
                coin -= 30;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            if(coin >= 20) { 
                itemsound.Play();           
                HandleKeyInput(6);
                coin -= 20;
            }
        }     

        if (score == 0 && dongGenerator.isActive) {
            if(stage1Text!=null){
                stage1Text.SetActive(true);
                StartCoroutine(DeactivateStage(stage1Text, 3));
            }
            
        }
        else if (score == 10) {
            if(stage2Text!=null){
                stage2Text.SetActive(true);
                StartCoroutine(DeactivateStage(stage2Text, 3));
            }            
        }
        else if (score == 20) {
            if(stage3Text!=null){
                stage3Text.SetActive(true);
                StartCoroutine(DeactivateStage(stage3Text, 3));
            }
        }
    }
    void HandleKeyInput(int key){
        photonView.RPC("Notifyotherclients", RpcTarget.Others, key);
    }
    [PunRPC]
    void Notifyotherclients(int key){
        // 다른 클라이언트에게 전달될 로직
        Debug.Log($"{key}번 키가 다른 클라이언트에서 눌렸습니다.");
        if(key ==4){
            dongAttackGenerator.Activate();
            StartCoroutine(DeactivateAttack(5));
        }
        if(key==5){
            dongGenerator.FiveItemActivate();
        }
        if(key==6){
            GameObject fartinstance = Instantiate(fartCloud);
            fartinstance.transform.position = new Vector3(0, -3.5f, 0);
            fartinstance.AddComponent<Fart_Controller>();
        }
        if(key==7){
            winsound.Play();
            winPanel.SetActive(true);
            GameObject[] allDdong = GameObject.FindGameObjectsWithTag("Ddong");
            foreach (GameObject dong in allDdong) {
                Destroy(dong);
            }
            dongGenerator.Deactivate();
        }

    }

    IEnumerator DeactivateAttack(float time) {
        yield return new WaitForSeconds(time);
        dongAttackGenerator.Deactivate();
    }
    IEnumerator DeactivateStage(GameObject gameObject, float time) {
        yield return new WaitForSeconds(time);
        if(gameObject!=null){
            gameObject.SetActive(false);
        }
    }

    // 일정 시간 후에 우산을 비활성화하는 코루틴입니다.
    IEnumerator DeactivateUmbrellaAfterTime(float time) {
        yield return new WaitForSeconds(time);
        umbrella.SetActive(false);
        yellowcircle3.SetActive(false);
    }
    IEnumerator DeactivateBbAfterTime(float time) {
        yield return new WaitForSeconds(time); // 5초간 대기
        dongGenerator.Activate();
        Bbtext.SetActive(false);
        yellowcircle1.SetActive(false);
    }
    public void ActivateToilet() {
        isToiletActive = true;
        GameObject[] allDdong = GameObject.FindGameObjectsWithTag("Ddong");
        Vector3 toiletPosition = toilet.transform.position;

        foreach (GameObject dong in allDdong) {
            StartCoroutine(MoveToToilet(dong, toiletPosition, 0.5f)); 
        }
        StartCoroutine(Deactivatetoilet());
    }
    IEnumerator MoveToToilet(GameObject dong, Vector3 toiletPosition, float duration) {
        Vector3 startPosition = dong.transform.position;
        float elapsed = 0;

        while (elapsed < duration) {
            if(dong == null) yield break;
            float t = elapsed / duration;
            dong.transform.position = Vector3.Lerp(startPosition, toiletPosition, movementCurve.Evaluate(t));
            elapsed += Time.deltaTime;
            yield return null;
        }
        if(dong!=null){
            Destroy(dong, 0.5f); // 똥을 비활성화하거나 제거합니다.
        }
    }
    IEnumerator Deactivatetoilet() {
        yield return new WaitForSeconds(1f);
        isToiletActive = false;
        toilet.SetActive(false); // 변기 비활성화
        yellowcircle2.SetActive(false);
    }
    public void GameOver() {
        isGameOvered = true;
        finalscoretext.text = "" + score;
        gameOverPanel.SetActive(true);
        losesound.Play();
    }
    public void RestartGame() {
        foreach (var dong in FindObjectsOfType<DongController>()) {
            Destroy(dong.gameObject);
        }
        gameOverPanel.SetActive(false);
        score = 0;
        coin = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 자기 자신 씬 보여주기
    }
    public void SaveScore() {
        GameManager.Instance.Score = score; // 점수를 게임 매니저에 저장
        SceneManager.LoadScene("ScoreScene");
    }

    public void SendLoseMessage(){
        photonView.RPC("Notifyotherclients", RpcTarget.Others, 7);
    }
    public void GoBacktoMainMenu() {
        
        Debug.Log("StartScene으로 돌아갈 차례");
        SceneManager.LoadScene("StartScene");
    }
    
    public void poopsound(){
        audiosource.Play();
    }
}
