using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    private static int score;
    private Text ScoreText;
    public GameObject SceneManager;
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    public int Score { get { return score; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(SceneManager);
    }
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
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
