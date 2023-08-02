using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int Addscorepoint = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject gm = GameObject.Find("ScoreManager");
            gm.GetComponent<ScoreManager>().AddScore(Addscorepoint);
            GetPoint();
        }
    }
    void GetPoint()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
