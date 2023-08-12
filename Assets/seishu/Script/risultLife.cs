using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class risultLife : MonoBehaviour
{
    int finalScore = LifeManager.Instance.life; // 最終的なスコアを取得
    private Text RisultLifeText;
    // Start is called before the first frame update
    void Start()
    {
        RisultLifeText = GameObject.Find("risultlife").GetComponent<Text>();
        SetRisultText(finalScore);
    }
    void SetRisultText(int life)
    {
        if (life <= 0)
        {
            life = 0;
            RisultLifeText.text = "残りライフ・・・" + life.ToString();
        }
        else
        {
            RisultLifeText.text = "残りライフ・・・" + life.ToString();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
