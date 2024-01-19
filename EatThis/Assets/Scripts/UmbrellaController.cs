using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaController : MonoBehaviour
{
    public Transform Idle; // 캐릭터의 Transform
    public Vector3 offset = new Vector3(0, 3, 0); // 캐릭터와의 오프셋, 필요에 따라 조정
    
    // Start is called before the first frame update
    void Start()
    {
        Idle = GameObject.FindGameObjectWithTag("Player").transform;
        if (Idle != null) {
            // 우산을 캐릭터의 자식 오브젝트로 설정
            transform.SetParent(Idle);

            // 캐릭터의 상단에 우산 위치 설정
            transform.localPosition = offset;

            // 필요하다면 우산의 회전도 조정할 수 있습니다.
            transform.localRotation = Quaternion.identity;
        }
        else{
            Debug.LogError("Player object not found for umbrella. Please set the Idle transform in the inspector or tag the player object with 'Player'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Idle != null) {
            // 캐릭터의 상단에 우산 위치 설정
            transform.localPosition = offset;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ddong"){
            Destroy(collision.gameObject);
        }
    }

}
