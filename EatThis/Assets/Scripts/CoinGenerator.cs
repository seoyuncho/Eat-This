using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinprefab;
    public GameObject rainbowimage;
    public GameObject rainbowcoinprefab;

    private bool goldengoosemode = false;
    private bool isActive = true;

    float span1 = 2f;
    float span_goldengoose = 0.05f;
    float delta1 = 0;
    public void ActivateGoldenGooseMode(){
        goldengoosemode = true;
    }
    public void DeactivateGoldenGooseMode() {
        goldengoosemode = false;
    }
    public void Activate(){
        isActive = true;
    }
    public void Deactivate(){
        isActive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rainbowimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            delta1 += Time.deltaTime;
            if(goldengoosemode){
                rainbowimage.SetActive(true);
                if(delta1 > span_goldengoose){
                    delta1=0;
                    GameObject coin = Instantiate(rainbowcoinprefab) as GameObject;
                    int x_position = Random.Range(-10,10);
                    coin.transform.position = new Vector3(x_position, 4, 0);
            }

            }
            else {
                if(delta1 > span1) {
                    rainbowimage.SetActive(false);
                    delta1 = 0;
                    GameObject coin = Instantiate(coinprefab) as GameObject;
                    int x_position = Random.Range(-10,10);
                    coin.transform.position = new Vector3(x_position, 4, 0);
                }
            }
        }
    }
}
