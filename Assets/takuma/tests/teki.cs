using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("何かに当たった");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに当たった");
        }
    }
}
