using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    //テキストの点滅
    public float textSpeed = 0.5f;//点滅スピード
    [SerializeField]private Text text;//テキスト
    private float time; //点滅最大と最小の時間
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }
    //テキストを点滅
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * textSpeed;//点滅スピード
        color.a = Mathf.Sin(time);
        return color;
    }
}
