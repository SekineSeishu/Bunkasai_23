using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int Addscorepoint = 1;//追加ポイント
    private AudioSource audio;
    public AudioClip PointSE;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //コインSE
            audio.PlayOneShot(PointSE);
            //GameObject gm = GameObject.Find("ScoreManager");
            //gm.GetComponent<ScoreManager>(). AddScore(Addscorepoint);
            ScoreManager.Instance.AddScore(Addscorepoint);
            GetPoint();
        }
    }
    void GetPoint()
    { 
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
