using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    //[SerializeField] private float slowTimeScale = 0.5f; // ���Ԃ�x�����銄��
    //[SerializeField] private float slowDuration = 0.02f;    // ���Ԃ�x�����鎝������

    public int PullLifepoint = 1;
    //public GameObject hp;
    public bool on_damage = false;       //�_���[�W�t���O
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        // �_�ŏ����ׂ̈ɌĂяo���Ă���
        renderer = gameObject.GetComponent<SpriteRenderer>();
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
   
