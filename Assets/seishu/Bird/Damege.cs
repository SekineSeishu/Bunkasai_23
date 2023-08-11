using System.Collections;
using UnityEngine;

public class Damege : MonoBehaviour
{
    //[SerializeField] private float slowTimeScale = 0.5f; // 時間を遅くする割合
    //[SerializeField] private float slowDuration = 0.02f;    // 時間を遅くする持続時間

    public int PullLifepoint = 1;
    //public GameObject hp;
    public bool on_damage = false;       //ダメージフラグ
    private SpriteRenderer renderer;
    private AudioSource audio;
    public AudioClip DamegeSE;
    // Start is called before the first frame update

    public GameObject electric_effect;
    public GameObject damage_effect;
    public GameObject effect_spawn_point;

    void Start()
    {
        // 点滅処理の為に呼び出しておく
        renderer = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.AddComponent<AudioSource>();

        electric_effect = (GameObject)Resources.Load("electric_effect");
        damage_effect = (GameObject)Resources.Load("damage_effect");
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
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
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Jellyfish_move>() && !on_damage)
        {
            Instantiate(electric_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }
        if (collider.gameObject.GetComponent<Shark_move2>() && !on_damage)
        {
            Debug.Log("サメに当たった");
            Instantiate(damage_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }
        if (collider.gameObject.GetComponent<Muraenid_move>() && !on_damage)
        {
            Instantiate(damage_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }
        // on damage
        if (!on_damage && collider.gameObject.tag == "Enemy")
        {
            //ダメージSE
            audio.PlayOneShot(DamegeSE);
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
   

