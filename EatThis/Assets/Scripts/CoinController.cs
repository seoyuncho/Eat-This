using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    float speed = -2.5f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime)); 
        if(transform.position.y < -5.0f){
            Destroy(gameObject);
        }
    }
}
