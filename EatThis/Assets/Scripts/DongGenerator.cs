using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DongGenerator : MonoBehaviour
{
    public GameObject dongprefab;
    public GameObject donglargeprefab;
    public GameObject dongfastprefab;
    public LineRenderer warningLine;
    // public LineRenderer warningLine; // 경고 선 Line Renderer
    public bool isActive = true;
    public bool isfiveitemActive = false;

    float span = 0.8f;
    float delta = 0;
    
    // Start is called before the first frame update
    public void Activate(){
        isActive = true;
    }
    public void Deactivate(){
        isActive = false;
    }
    public void FiveItemActivate(){
        isfiveitemActive = true;
    }
    public void FiveItemDeactivate(){
        isfiveitemActive = false;
    }

    void Start()
    {
        warningLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isfiveitemActive){
            int randompassvalue = Random.Range(-9,9);
            for (int i=-9; i<=10; i++){
                if((i == randompassvalue) || (i==randompassvalue+1)) continue;
                GameObject ddong = Instantiate(dongprefab);
                ddong.transform.position = new UnityEngine.Vector3(i, 6, 0);
            }
            isfiveitemActive = false;
        }
        if(isActive) {
            delta += Time.deltaTime;
            if(GameManager.score >=40 && delta>span){
                delta = 0;
                int x_position = Random.Range(-9, 9);
                warningLine.SetPosition(0, new UnityEngine.Vector3(x_position, 6, 0)); // 상단
                warningLine.SetPosition(1, new UnityEngine.Vector3(x_position, -5, 0)); // 하단                
                warningLine.enabled = true;
                UnityEngine.Vector3 position = new UnityEngine.Vector3(x_position, 4, 0);
                StartCoroutine(DeactivateWarningLine(3));
                StartCoroutine(Delay(0.5f, position));
                GameObject ddonglarge = Instantiate(donglargeprefab) as GameObject;
                int x_position_1 = Random.Range(-9, 9);
                ddonglarge.transform.position = new UnityEngine.Vector3(x_position_1, 6, 0);
                GameObject ddong = Instantiate(dongprefab) as GameObject;
                int x_position_2 = Random.Range(-9, 9);
                ddong.transform.position = new UnityEngine.Vector3(x_position_2, 6, 0);
            }
            else if (GameManager.score >= 20 && delta > span) {
                delta = 0;
                int x_position = Random.Range(-8, 8);
                warningLine.SetPosition(0, new UnityEngine.Vector3(x_position, 6, 0)); // 상단
                warningLine.SetPosition(1, new UnityEngine.Vector3(x_position, -5, 0)); // 하단                
                warningLine.enabled = true;
                UnityEngine.Vector3 position = new UnityEngine.Vector3(x_position, 4, 0);
                StartCoroutine(DeactivateWarningLine(3));
                StartCoroutine(Delay(0.5f, position));
            }
            // 먼저 큰 똥에 대한 조건을 체크합니다.
            else if (GameManager.score >= 10 && delta > span) {
                delta = 0;
                GameObject ddonglarge = Instantiate(donglargeprefab) as GameObject;
                int x_position = Random.Range(-8, 8);
                ddonglarge.transform.position = new UnityEngine.Vector3(x_position, 6, 0);
            }
            // 그 다음 일반 똥 생성 조건을 체크합니다.
            else if (delta > span) {
                delta = 0;
                GameObject ddong = Instantiate(dongprefab) as GameObject;
                int x_position = Random.Range(-8, 8);
                ddong.transform.position = new UnityEngine.Vector3(x_position, 6, 0);
            }
        }
    }

    IEnumerator DeactivateWarningLine(float time){
        yield return new WaitForSeconds(time);
        warningLine.enabled = false;
    }
    IEnumerator Delay(float time, UnityEngine.Vector3 position){
        yield return new WaitForSeconds(time);
        GameObject ddongfast = Instantiate(dongfastprefab) as GameObject;
        ddongfast.transform.position = new UnityEngine.Vector3(position.x, 6, 0);
    }
}
