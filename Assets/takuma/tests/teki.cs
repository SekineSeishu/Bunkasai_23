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
        Debug.Log("âΩÇ©Ç…ìñÇΩÇ¡ÇΩ");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇ¡ÇΩ");
        }
    }
}
