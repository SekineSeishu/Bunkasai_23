using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish_move : MonoBehaviour
{
    private bool move_end = true;
    private int angle;
    private float move_num;
    private int move_count;

    public float speed = 0.05f;
    public Vector2 v_move_num = new Vector2 (25, 50);

    void FixedUpdate()
    {
        if (move_end == false)
        {
            transform.Translate(0, speed, 0, Space.Self);
            move_count++;
            if (move_num <= move_count)
            {
                move_end = true;
                move_count = 0;
            }
        }
        if (move_end == true)
        {
            //ˆÚ“®—Ê
            move_num = Random.Range(v_move_num.x, v_move_num.y);
            //ƒ‰ƒ“ƒ_ƒ€‚È•ûŒü‚ðŒü‚­
            angle = Random.Range(0, 360);
            transform.eulerAngles = new Vector3(0, 0, angle);
            move_end = false;
        }
    }
}
