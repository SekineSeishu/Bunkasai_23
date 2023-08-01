using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    //Time.timeScaleに設定する値
    [SerializeField] private float timeScale = 0.1f;
    //時間を遅くしている時間
    [SerializeField] private float slowTime = 1f;
    //経過時間
    private float elapsedTime = 0f;
    //時間を遅くしているかどうか
    private bool isSlowDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スローダウンフラグがtrueの時は時間計測
        if (isSlowDown)
        {
            elapsedTime += Time.unscaledDeltaTime;
            if (elapsedTime >= slowTime)
            {
                SetNormalTime();
            }
        }
    }
    //時間を遅らせる処理
    public void SlowDown()
    {
        elapsedTime = 0f;
        Time.timeScale = 0f;
        Time.timeScale = timeScale;
    }
    //時間を元に戻す処理
    public void SetNormalTime()
    {
        Time.timeScale = 1f;
        isSlowDown = false;
    }
}
