using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    public float TextSpeed = 0.5f;
    private Text text;
    private float time; 
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * TextSpeed;
        color.a = Mathf.Sin(time);
        return color;
    }
}
