using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSE : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip goalSE;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(goalSE);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
