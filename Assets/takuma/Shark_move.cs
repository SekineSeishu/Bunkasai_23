using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_move : MonoBehaviour
{
    public enum Shark_Condition
    {
        Patrolling,
        Alert,
        Battle,
    }
    public Shark_Condition Condition;
    private GameObject Player;
    private GameObject Shark;
    public float move_speed = 0.3f;

    void Start()
    {
        Condition = Shark_Condition.Patrolling;
        Player = GameObject.Find("Player");
        Shark = transform.Find("Shark").gameObject;
    }
    void Update()
    {
        //this.transform.LookAt(Player.transform);
    }
    void FixedUpdate()
    {
        switch (Condition)
        {
            case Shark_Condition.Patrolling:
                break;

            case Shark_Condition.Alert:
                break;

            case Shark_Condition.Battle:
                this.transform.LookAt(Player.transform);
                Shark.transform.localPosition += new Vector3(0, 0, move_speed);
                this.transform.position = Shark.transform.position;
                Shark.transform.localPosition = Vector3.zero;
                break;
        }
        /*if (Input.GetKey(KeyCode.W))
        {
            Shark.transform.localPosition += new Vector3(0, 0, 0.1f);
            this.transform.position = Shark.transform.position;
            Shark.transform.localPosition = Vector3.zero;
        }*/
    }
    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject == Player) Condition = Shark_Condition.Battle;
    }
    void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject == Player) Condition = Shark_Condition.Patrolling;
    }
}
