using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameObject player;
    public float cameraZ = -17.3f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, cameraZ);
    }
}
