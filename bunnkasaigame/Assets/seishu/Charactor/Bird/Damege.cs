using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    public int Pullscorepoint = 1;
    public GameObject hp;
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
        //�_���[�W�t���OON
        on_damage = true;

        //�v���C���[�����ɔ�΂�
        //float s = 100f * Time.deltaTime;
        //transform.Translate(Vector3.up * s);
        // �R���[�`���J�n
        StartCoroutine("WaitForIt");
    }
    IEnumerator WaitForIt()
    {
        // 2�b�ԏ������~�߂�
        yield return new WaitForSeconds(2);

        // �P�b��_���[�W�t���O��false�ɂ��ē_�ł�߂�
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
