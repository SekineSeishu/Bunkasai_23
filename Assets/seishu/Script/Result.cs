using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //���U���g�V�[���ł̕\��
    int finalLife = LifeManager.Instance.life; // �ŏI�I�ȃ��C�t���擾
    int finalScore = ScoreManager.Instance.Score; // �ŏI�I�ȃX�R�A���擾
    [SerializeField] private Text risultScoreText;//�X�R�A�\��
    [SerializeField] private Text risultLifeText;//���C�t�\��

    void Start()
    {
        SetRisultText(finalLife,finalScore);
    }

    //�X�R�A�ƃ��C�t��\��
    void SetRisultText(int life,int score)
    {
          risultLifeText.text = "�c�胉�C�t�E�E�E" + life.ToString();
          risultScoreText.text =score.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
