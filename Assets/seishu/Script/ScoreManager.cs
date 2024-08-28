using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    private static int score;//スコア
    private Text ScoreText;//スコア表示
    public GameObject scoreManager;

    private Vector3 initialPosition;//リセットポジション
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    public int Score { get { return score; } }//リザルトシーンでスコアを渡す

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
        DontDestroyOnLoad(scoreManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        SetScoreText(score);
    }

    //スコア表示
    private void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
    }
    //スコアをプラスしてUIを更新
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
            Destroy(scoreManager);
        }
    }
}
