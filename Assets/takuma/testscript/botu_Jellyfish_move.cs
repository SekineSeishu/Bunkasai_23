using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botu_Jellyfish_move : MonoBehaviour
{
    [Header("--- 基本行動 ---")]
            [Tooltip("行動範囲")] //使用方法の詳細はTAKUMAのシーンまでお願いします
    public GameObject move_area;

            [Tooltip("移動量")]//増やすと一回の行動に付き移動する蝶が増えます
    public Vector3 move_num = Vector3.zero;

            [Tooltip("移動の滑らかさ")]//数が増えれば増えるほど移動中の挙動が細かくなります
    public int move_count = 10;

    public int hou = 0;
    [Header("--- 移動速度 ---")]

    public float up_move_num = 0.1f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) StartCoroutine("IE_Jellyfish_move");
    }

    IEnumerator IE_Jellyfish_move()
    {
        for (; hou == 0;)//方向が指定されてないなら起動
        {
            hou = Random.Range(-1, 2);//此処で方向を決める
            if (hou != 0)//方向が決まったなら
            {
                Debug.Log(hou);
                if(hou > 0) Debug.Log("右");
                if(hou < 0) Debug.Log("左");
                break;//方向が指定されたので次に以降
            }
        }
        for (int i = 0; i < move_count; i++)//move_countの数だけ繰り返し移動する
        {
            move_num += new Vector3(0.1f * hou,0.3f ,0);

            this.transform.transform.position = move_num;

            yield return new WaitForSeconds(up_move_num);
            Debug.Log(move_num);
        }
        hou = 0;
    }
}
