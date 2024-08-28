using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private int Addscorepoint = 1;//追加ポイント
    private AudioSource audio;//SEを流す先
    [SerializeField] private AudioClip PointSE;//獲得SE

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        //コイン獲得
        if (collider.gameObject.tag == "Player")
        {
            audio.PlayOneShot(PointSE);
            ScoreManager.Instance.AddScore(Addscorepoint);
            GetPoint();
        }
    }

    //獲得したコインを削除
    private void GetPoint()
    { 
        Destroy(gameObject);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
