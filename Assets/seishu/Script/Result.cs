using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //リザルトシーンでの表示
    int finalLife = LifeManager.Instance.life; // 最終的なライフを取得
    int finalScore = ScoreManager.Instance.Score; // 最終的なスコアを取得
    [SerializeField] private Text risultScoreText;//スコア表示
    [SerializeField] private Text risultLifeText;//ライフ表示

    void Start()
    {
        SetRisultText(finalLife,finalScore);
    }

    //スコアとライフを表示
    void SetRisultText(int life,int score)
    {
          risultLifeText.text = "残りライフ・・・" + life.ToString();
          risultScoreText.text =score.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
