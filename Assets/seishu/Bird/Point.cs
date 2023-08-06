using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int Addscorepoint = 1;//追加ポイント

    void Start()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
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
