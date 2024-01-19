using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start() {
        Destroy(gameObject, 0.5f); // 3초 후에 자동으로 파괴
    }
}
