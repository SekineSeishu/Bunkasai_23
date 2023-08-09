using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shark_move2 : MonoBehaviour
{
    public enum Shark_Condition
    {
        Patrolling,//�ʏ�
        Alert,//�x��
        Battle,//�퓬
    }
    public Shark_Condition Condition;

    private GameObject player;
    private GameObject shark;
    private GameObject effect_spawn_point;
    //���v���n�u�p
    private GameObject exclamation_mark;
    private GameObject question_mark;

    private Vector3 respawn;
    public int pat_num;
    public float Detection_distance = 10;
    public int current_pos_num = 0;
    public float move_speed = 0.08f;
    public List<GameObject> Pat_pos_list = new List<GameObject>();
    void Start()
    {
        respawn = this.transform.position;
        Condition = Shark_Condition.Patrolling;
        //��Find����
        player = GameObject.Find("Player");
        shark = transform.Find("Shark").gameObject;
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
        //��Resources.Load����
        exclamation_mark = (GameObject)Resources.Load("exclamation_mark");
        question_mark = (GameObject)Resources.Load("question_mark");

        Transform Main = transform.parent;
        Transform Patrolling_position = Main.Find("Patrolling_position");
        pat_num = Patrolling_position.childCount;
        for (int i = 0; i < pat_num; i++)
        {
            Transform child = Patrolling_position.GetChild(i);
            Pat_pos_list.Add(child.gameObject);
        }
    }
    void Update()
    {
        if ((player.transform.position - shark.transform.position).magnitude <= Detection_distance)
        {
            if (Condition != Shark_Condition.Battle)
            {
                Debug.Log("�C�Â��ꂽ�I");
                Instantiate(exclamation_mark, effect_spawn_point.
                transform.position, Quaternion.identity, this.transform);
            }
            Condition = Shark_Condition.Battle;
        }
        if ((player.transform.position - shark.transform.position).magnitude > Detection_distance)
        {
            if (Condition != Shark_Condition.Patrolling)
            {
                Debug.Log("�����ꂽ�I");
                Instantiate(question_mark, effect_spawn_point.
                transform.position, Quaternion.identity, this.transform);
            }
            Condition = Shark_Condition.Patrolling;
        }
    }
    void FixedUpdate()
    {
        switch (Condition)
        {
            case Shark_Condition.Patrolling://������
                for (int i = 0; i < pat_num; i++)
                {
                    if (current_pos_num == i)
                    {
                        LookAt2D_ob(Pat_pos_list[i]);
                    }
                }
                break;
            case Shark_Condition.Alert://�x����
                break;
            case Shark_Condition.Battle://�ǐՒ�
                LookAt2D_ob(player);
                break;
        }
    }
    //�������蔻�菈��
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("��������");
        if (other.gameObject.CompareTag("Pat_pos"))
        {
            if (current_pos_num == (pat_num - 1)) current_pos_num = 0;
            else current_pos_num++;
        }
    }
    //���֐�
    void LookAt2D_ob(GameObject target)
    {
        this.transform.LookAt(target.transform.position);
        shark.transform.localPosition += new Vector3(0, 0, move_speed);
        this.transform.position = shark.transform.position;
        shark.transform.localPosition = Vector3.zero;
    }
}