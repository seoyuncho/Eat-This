using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongController : MonoBehaviour
{
    float speed = -2.5f;
    public GameObject explosionPrefab;// 폭발 효과 프리팹 참조
    private GameManager gamemanager;


    // Update is called once per frame
    void Start(){
        gamemanager = FindObjectOfType<GameManager>();
    }
    void Update() {
        transform.Translate(new Vector2(0, speed * Time.deltaTime )); 
        if (transform.position.y < -4.5f){
            gamemanager.poopsound();
            TriggerExplosion();
            Destroy(gameObject); // 똥 오브젝트 파괴
        }
    }

    void TriggerExplosion() {
        if (explosionPrefab != null) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
