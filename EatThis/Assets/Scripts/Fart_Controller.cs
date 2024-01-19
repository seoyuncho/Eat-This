using System.Collections;
using UnityEngine;

public class Fart_Controller : MonoBehaviour
{
    public float duration = 7.0f; // 지속 시간
    public float shakeSpeed = 20.0f; // 좌우로 흔들리는 속도
    public float shakeAmount = 0.5f; // 좌우로 흔들리는 정도
    private float timePassed = 0f;

    void Update()
    {
        // 시간 갱신
        timePassed += Time.deltaTime;

        // 좌우로 흔들리는 애니메이션
        float xOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        transform.position += new Vector3(xOffset, 0f, 0f);

        // 지속 시간이 끝나면 자기 자신을 파괴
        if (timePassed >= duration)
            Destroy(gameObject);
    }
}