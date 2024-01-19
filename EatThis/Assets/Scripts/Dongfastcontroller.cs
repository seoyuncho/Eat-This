using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongfastController : MonoBehaviour
{
    float speed = -30.0f;
    public GameObject explosionPrefab; // 폭발 효과 프리팹 참조
    // Start is caled before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime )); 
        if(transform.position.y < -5.0f){
            GameManager.score++;
            TriggerExplosion();
            Destroy(gameObject);
        }
    }
    void TriggerExplosion() {
        if (explosionPrefab != null) {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }
}
