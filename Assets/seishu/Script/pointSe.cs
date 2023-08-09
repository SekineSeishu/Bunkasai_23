using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSe : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip PointSE;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "point")
        {
            audio.PlayOneShot(PointSE);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
