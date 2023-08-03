using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_move : MonoBehaviour
{
    public enum Shark_Condition
    {
        Patrolling,//í èÌ
        Alert,//åxâ˙
        Battle,//êÌì¨
    }
    public Shark_Condition Condition;
    private GameObject Player;
    private GameObject Shark;
    private Vector3 respawn;
    public float move_speed = 0.3f;

    void Start()
    {
        Condition = Shark_Condition.Patrolling;
        Player = GameObject.Find("Player");
        Shark = transform.Find("Shark").gameObject;
        respawn = this.transform.position;
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
                //this.transform.position = respawn;
                this.transform.LookAt(respawn);
                Shark.transform.localPosition += new Vector3(0, 0, move_speed);
                this.transform.position = Shark.transform.position;
                Shark.transform.localPosition = Vector3.zero;
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
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) Condition = Shark_Condition.Battle;
    }
    void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject == Player) Condition = Shark_Condition.Patrolling;
    }
}
