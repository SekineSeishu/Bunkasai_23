using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadData : MonoBehaviour
{
    private Text risulttext;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager sm = FindObjectOfType<ScoreManager>();
        risulttext = GameObject.Find("Score").GetComponent<Text>();
        risulttext.text = sm.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
