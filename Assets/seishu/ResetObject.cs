using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // リセットしたいタイミングで ResetEmptyObject オブジェクトを取得
        ScoreManager sm = FindObjectOfType<ScoreManager>();
        // ResetEmptyObject が見つかった場合にリセット処理を実行
        if (sm != null)
        {
            sm.ResetObjectTransform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
