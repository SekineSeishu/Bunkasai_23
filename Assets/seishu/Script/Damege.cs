using System.Collections;
using UnityEngine;

public class Damege : MonoBehaviour
{
    public int PullLifepoint = 1;//�q�b�g�_���[�W
    public bool on_damage = false; //�_���[�W�t���O
    private SpriteRenderer renderer;//�_��
    private AudioSource audio;//SE�𗬂���
    public AudioClip damegeSE;//�_���[�WSE


    public GameObject electric_effect;//�_���[�W�G�t�F�N�g1
    public GameObject damage_effect;//�_���[�W�G�t�F�N�g2
    public GameObject effect_spawn_point;//�G�t�F�N�g�ʒu

    void Start()
    {
        // �_�ŏ����ׂ̈ɌĂяo���Ă���
        renderer = gameObject.GetComponent<SpriteRenderer>();
        audio = gameObject.GetComponent<AudioSource>();

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
            audio.PlayOneShot(damegeSE);
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
    
    
}
   

