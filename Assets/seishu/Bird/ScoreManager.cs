using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    private Text ScoreText;
    public GameObject SManager;
    //リセット用
    private Vector3 initialPosition;
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    public int Score { get { return score; } }
    private void Awake()
    {
        initialPosition = transform.position;//保存
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(SManager);
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
    public void ResetObjectTransform()
    {
        // オブジェクトの位置を初期値にリセット
        transform.position = initialPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        // SceneManagerの名前がタイトルの場合にScoreManagerを破棄
        if (SceneManager.GetActiveScene().name == "titol")
        {
            Destroy(gameObject);
        }
    }
}
