using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_bool : MonoBehaviour
{
    public bool area_bool;
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Jellyfish_move>())
        {
            area_bool = false;
        }
    }
}
