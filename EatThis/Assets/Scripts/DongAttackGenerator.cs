using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongAttackGenerator : MonoBehaviour
{
    public GameObject dongAttack;
    float span = 3.0f;
    float delta = 0;
    public bool isActive = true;
    public void Activate(){
        isActive = true;
    }
    public void Deactivate(){
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive) {
            delta += Time.deltaTime;
            if (delta > span) {
                delta = 0;
                GameObject ddong = Instantiate(dongAttack) as GameObject;
                ddong.transform.position = new UnityEngine.Vector3(-10, -3, 0);
            }
        }
    }
}
