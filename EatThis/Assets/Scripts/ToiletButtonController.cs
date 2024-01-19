using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletButtonController : MonoBehaviour
{
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.coin >= 10) {
            // 코인이 5개 이상일 때 완전한 우산
            objectRenderer.material.color = new Color(1f, 1f, 1f, 1f); // 완전 불투명
        } else {
            // 코인이 5개 미만일 때 반투명한 우산
            objectRenderer.material.color = new Color(1f, 1f, 1f, 0.5f); // 반투명
        }
    }
}
