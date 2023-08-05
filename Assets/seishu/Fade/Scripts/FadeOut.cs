using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Fade fade;
    private AudioSource audio;
    public AudioClip WaterSE;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot(WaterSE);
        fade.FadeOut(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
