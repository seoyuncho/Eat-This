using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongAttackController : MonoBehaviour
{
    float speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0)); 
    }
}
