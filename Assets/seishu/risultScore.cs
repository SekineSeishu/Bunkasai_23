using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class risultScore : MonoBehaviour
{
    int finalScore = ScoreManager.Instance.Score; // 最終的なスコアを取得
    private Text RisultText;
    // Start is called before the first frame update
    void Start()
    {
        RisultText = GameObject.Find("risultScore").GetComponent<Text>();
        SetRisultText(finalScore);
    }
    void SetRisultText(int score)
    {
        RisultText.text = score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
