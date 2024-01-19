using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseGenerator : MonoBehaviour
{
    private bool isActivate = true;
    public GameObject gooseprefab;
    float span2 = 25f;
    float delta2 = 0;
    // Start is called before the first frame update
    public void Deactivate(){
        isActivate = false;
    }
    public void Activate(){
        isActivate = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivate){
            delta2 +=Time.deltaTime;
            if(delta2 > span2){
                delta2=0;
                GameObject goose = Instantiate(gooseprefab) as GameObject;
                int x_position = Random.Range(-10,10);
                goose.transform.position = new Vector3(x_position, 4, 0);
            }
        }    
    }
}
