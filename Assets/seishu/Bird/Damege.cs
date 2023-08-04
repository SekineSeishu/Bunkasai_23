using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    //[SerializeField] private float slowTimeScale = 0.5f; // 時間を遅くする割合
    //[SerializeField] private float slowDuration = 0.02f;    // 時間を遅くする持続時間

    public int PullLifepoint = 1;
    //public GameObject hp;
    public bool on_damage = false;       //ダメージフラグ
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        // 点滅処理の為に呼び出しておく
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ダメージフラグがtrueで有れば点滅させる
        if (on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // on damage
        if (!on_damage && collision.gameObject.tag == "Enemy")
        {
            //hp.gameObject.SendMessage("onDamage", 10);
            GameObject gm = GameObject.Find("LifeManager");
            gm.GetComponent<LifeManager>().PullLife(PullLifepoint);
            //StartCoroutine(TriggerTimeSlow());
            OnDamageEffect();
        }

    }

    void OnDamageEffect()
    {
        //ダメージフラグON
        on_damage = true;
        //StartCoroutine(TriggerTimeSlow());
        //プレイヤーを後ろに飛ばす
        //float s = 100f * Time.deltaTime;
        //transform.Translate(Vector3.up * s);
        // コルーチン開始
        StartCoroutine("WaitForIt");
    }
    IEnumerator WaitForIt()
    {
       
        // 1.5秒間処理を止める
        yield return new WaitForSeconds(1.5f);
        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
    /*public IEnumerator TriggerTimeSlow()
    {
        // タイムスケールを遅くする
        Time.timeScale = slowTimeScale;
        Debug.Log("ザ・ワールド！");

        // 持続時間だけ待機
        yield return new WaitForSecondsRealtime(slowDuration);

        // タイムスケールを元に戻す
        Time.timeScale = 1f;
        Debug.Log("再び時は動き出す");
        
    }*/
    
}
   

