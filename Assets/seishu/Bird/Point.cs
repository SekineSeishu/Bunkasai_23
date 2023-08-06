using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int Addscorepoint = 1;//追加ポイント
    private Rigidbody rb;
    private Collider col;

    void Start()
    {
        col = GetComponent<BoxCollider>();
        col.isTrigger = true;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            notTrigger();
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
    void notTrigger()
    {
        col.isTrigger = false;
        Debug.Log("TriggerOFF");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
