using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    public int Pullscorepoint = 1;
    public GameObject hp;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // on damage
        if (!on_damage && collision.gameObject.tag == "Enemy")
        {
            //hp.gameObject.SendMessage("onDamage", 10);
            GameObject gm = GameObject.Find("ScoreManager");
            gm.GetComponent<ScoreManager>().PullScore(Pullscorepoint);
            OnDamageEffect();
        }
    }
    void OnDamageEffect()
    {
        //ダメージフラグON
        on_damage = true;

        //プレイヤーを後ろに飛ばす
        //float s = 100f * Time.deltaTime;
        //transform.Translate(Vector3.up * s);
        // コルーチン開始
        StartCoroutine("WaitForIt");
    }
    IEnumerator WaitForIt()
    {
        // 2秒間処理を止める
        yield return new WaitForSeconds(2);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
