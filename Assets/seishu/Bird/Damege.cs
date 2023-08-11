using System.Collections;
using UnityEngine;

public class Damege : MonoBehaviour
{
    //[SerializeField] private float slowTimeScale = 0.5f; // ���Ԃ�x�����銄��
    //[SerializeField] private float slowDuration = 0.02f;    // ���Ԃ�x�����鎝������

    public int PullLifepoint = 1;
    //public GameObject hp;
    public bool on_damage = false;       //�_���[�W�t���O
    private SpriteRenderer renderer;
    private AudioSource audio;
    public AudioClip DamegeSE;
    // Start is called before the first frame update

    public GameObject electric_effect;
    public GameObject damage_effect;
    public GameObject effect_spawn_point;

    void Start()
    {
        // �_�ŏ����ׂ̈ɌĂяo���Ă���
        renderer = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.AddComponent<AudioSource>();

        electric_effect = (GameObject)Resources.Load("electric_effect");
        damage_effect = (GameObject)Resources.Load("damage_effect");
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // �_���[�W�t���O��true�ŗL��Γ_�ł�����
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
            Debug.Log("�T���ɓ�������");
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
            //�_���[�WSE
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
        //�_���[�W�t���OON
        on_damage = true;
        //StartCoroutine(TriggerTimeSlow());
        //�v���C���[�����ɔ�΂�
        //float s = 100f * Time.deltaTime;
        //transform.Translate(Vector3.up * s);
        // �R���[�`���J�n
        StartCoroutine("WaitForIt");
    }
    IEnumerator WaitForIt()
    {
       
        // 1.5�b�ԏ������~�߂�
        yield return new WaitForSeconds(1.5f);
        // �P�b��_���[�W�t���O��false�ɂ��ē_�ł�߂�
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
    /*public IEnumerator TriggerTimeSlow()
    {
        // �^�C���X�P�[����x������
        Time.timeScale = slowTimeScale;
        Debug.Log("�U�E���[���h�I");

        // �������Ԃ����ҋ@
        yield return new WaitForSecondsRealtime(slowDuration);

        // �^�C���X�P�[�������ɖ߂�
        Time.timeScale = 1f;
        Debug.Log("�Ăю��͓����o��");
        
    }*/
    
}
   

