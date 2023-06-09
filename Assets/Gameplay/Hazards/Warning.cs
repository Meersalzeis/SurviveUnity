using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroySelf", 1);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
