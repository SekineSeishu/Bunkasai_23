using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    //�e�L�X�g�̓_��
    public float textSpeed = 0.5f;//�_�ŃX�s�[�h
    [SerializeField]private Text text;//�e�L�X�g
    private float time; //�_�ōő�ƍŏ��̎���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }
    //�e�L�X�g��_��
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * textSpeed;//�_�ŃX�s�[�h
        color.a = Mathf.Sin(time);
        return color;
    }
}
