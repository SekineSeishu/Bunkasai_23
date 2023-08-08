using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muraenid_move : MonoBehaviour
{
    private GameObject Muraenid;
    private GameObject player;
    public float Detection_distance = 0.2f;
    private int pat_num;
    private int current_pos_num = 0;
    public float move_speed = 0.05f;
    public List<GameObject> Pat_pos_list = new List<GameObject>();

    void Start()
    {
        Muraenid = transform.Find("Muraenid").gameObject;
        player = GameObject.Find("Player");

        Transform Main = transform.parent;
        Transform Patrolling_position = Main.Find("Patrolling_position");
        pat_num = Patrolling_position.childCount;

        for (int i = 0; i < pat_num; i++)
        {Transform child = Patrolling_position.GetChild(i);
            Pat_pos_list.Add(child.gameObject);}
        this.transform.position = Pat_pos_list[0].transform.position;
    }
    void Update()
    {
        if ((Pat_pos_list[current_pos_num].transform.position - Muraenid.transform.position).magnitude <= Detection_distance)
        {
            if (current_pos_num == (pat_num - 1))
            {
                current_pos_num = 1;
                this.transform.position = Pat_pos_list[0].transform.position;
            }
            else current_pos_num++;
        }
    }
    void FixedUpdate()
    {
        for (int i = 0; i < pat_num; i++)
        {
            if (current_pos_num == i)
            {
                LookAt2D_ob(Pat_pos_list[i]);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.CompareTag("Pat_pos"))
        {
            if (current_pos_num == (pat_num - 1))
            {
                current_pos_num = 1;
                this.transform.position = Pat_pos_list[0].transform.position;
            }
            else current_pos_num++;
        }*/
    }
    void LookAt2D_ob(GameObject target)
    {
        this.transform.LookAt(target.transform);
        Muraenid.transform.localPosition += new Vector3(0, 0, move_speed);
        this.transform.position = Muraenid.transform.position;
        Muraenid.transform.localPosition = Vector3.zero;
    }
}