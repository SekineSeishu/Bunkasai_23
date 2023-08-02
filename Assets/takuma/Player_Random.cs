using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Random : MonoBehaviour
{
    public Vector2 tate = Vector2.one;
    public Vector2 yoko = Vector2.one;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
this.transform.position = new Vector2(Random.Range(tate.x, tate.y), Random.Range(yoko.x, yoko.y));
        }
    }
}
