using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        SetScoreText(score);
    }
    private void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }
    public void AddScore(int point)
    {
        score += point;
        SetScoreText(score);
    }
    public void PullScore(int point)
    {
        score -= point;
        SetScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
