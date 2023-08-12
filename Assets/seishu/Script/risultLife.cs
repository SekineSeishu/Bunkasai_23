using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class risultLife : MonoBehaviour
{
    int finalScore = LifeManager.Instance.life; // �ŏI�I�ȃX�R�A���擾
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
            RisultLifeText.text = "�c�胉�C�t�E�E�E" + life.ToString();
        }
        else
        {
            RisultLifeText.text = "�c�胉�C�t�E�E�E" + life.ToString();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
