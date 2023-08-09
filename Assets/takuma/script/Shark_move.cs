using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using static UnityEngine.GraphicsBuffer;

public class Shark_move : MonoBehaviour
{
    public enum Shark_Condition
    {
        Patrolling,//通常
        Alert,//警戒
        Battle,//戦闘
    }
    public Shark_Condition Condition;

    private GameObject player;
    private GameObject shark;
    private GameObject effect_spawn_point;
    //↓プレハブ用
    private GameObject exclamation_mark;
    private GameObject question_mark;

    private Vector3 respawn;
    private int pat_num;
    public float Detection_distance = 10;
    public int current_pos_num = 0;
    public float move_speed = 0.3f;
    public List<GameObject> Pat_pos_list = new List<GameObject>();
    
    private IEnumerator cortine = null;
    private bool isMove = true;
    private const int RADIUS = 10;
    private const float MIN_DISTANCE = 2;
    private const float SPEED = 2;
    private const int DURING = 3;
    private const float MAX_HEIGHT = 23;
    private const float MIN_HEIGHT = -12;
    void Start()
    {
        respawn = this.transform.position;
        Condition = Shark_Condition.Patrolling;
        //↓Find処理
        player = GameObject.Find("Player");
        shark = transform.Find("Shark").gameObject;
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
        //↓Resources.Load処理
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
        #region 座標制限
        var pos = transform.position;
        //ここで諸々制限
        pos.y = Mathf.Clamp(pos.y, MIN_HEIGHT, MAX_HEIGHT);
        transform.position = pos;
        #endregion
        if ((player.transform.position - shark.transform.position).magnitude <= Detection_distance)
        {
            if (Condition != Shark_Condition.Battle)
            {
                Debug.Log("気づかれた！");
                Instantiate(exclamation_mark, effect_spawn_point.
                transform.position, Quaternion.identity, this.transform);
            }
            Condition = Shark_Condition.Battle;
        }
        if ((player.transform.position - shark.transform.position).magnitude > Detection_distance)
        {
            if (Condition != Shark_Condition.Patrolling)
            {
                Debug.Log("逃げれた！");
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
            case Shark_Condition.Patrolling://巡廻中
                if (isMove)
                {
                    if (cortine != null)
                    {
                        StopCoroutine(cortine);
                        cortine = null;
                    }
                    LookAt2D_ob(() => isMove = true);
                    isMove = false;
                }
                break;
            case Shark_Condition.Alert://警戒中
                break;
            case Shark_Condition.Battle://追跡中
                //LookAt2D_ob(player);
                if (isMove)
                {
                    if (cortine != null)
                    {
                        StopCoroutine(cortine);
                        cortine = null;
                    }
                    StartCoroutine(cortine = MoveTarget(player.transform.position, MIN_DISTANCE, DURING, () => isMove = true));
                    isMove = false;
                }
                this.transform.LookAt(player.transform.position);
                break;
        }
    }
    //↓当たり判定処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pat_pos"))
        {
            if (current_pos_num == (pat_num - 1)) current_pos_num = 0;
            else current_pos_num++;
        }
    }
    //↓関数
    void LookAt2D_ob(Action end = null)
    {
        var randomCircle = Random.insideUnitCircle * RADIUS;
        var targetPos = transform.position + new Vector3(randomCircle.x, randomCircle.y, 0);
        StartCoroutine(cortine = MoveTarget(targetPos, MIN_DISTANCE, DURING, end));
        /*
        shark.transform.localPosition += new Vector3(0, 0, move_speed);
        this.transform.position = shark.transform.position;
        shark.transform.localPosition = Vector3.zero;
        */
    }
    private IEnumerator MoveTarget(Vector3 targetPos, float minDistance, int during, Action end = null)
    {
        var time = 0f;
        var oldPos = transform.position;


        /*
        var targetAng = targetPos - transform.position;
        var axis = Vector3.Cross(transform.position, targetAng);
        var angle = Vector3.Angle(transform.position, targetAng) * ((axis.y < 0) ? -1 : 1);

        if (angle > 0)
            transform.rotation = Quaternion.Euler(0, -90, 0);
        else
            transform.rotation = Quaternion.Euler(0, 90, 0);
        */

        while (time < 0.9f)
        {
            transform.position = Vector3.Lerp(oldPos, targetPos, time);
            time += Time.deltaTime / during;
            yield return null;
        }
        if (end != null)
            end();
    }
}