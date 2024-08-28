using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //タイトルとリザルト画面の移動する背景
    public Transform respawnPosition; // リスポーン位置
    public float moveSpeed = 5f; // カメラの移動スピード

    private Vector3 originalPosition; // 初期位置

    // Start is called before the first frame update
    void Start()
    {
        // 初期位置に移動
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 目標位置に移動
        if (transform.position != respawnPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, respawnPosition.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // 目標位置に到達したらリスポーン
            Respawn();
        }
    }
    private void Respawn()
    {
        /// リスポーン処理をここに記述
        // カメラの位置を初期位置に戻す
        transform.position = originalPosition;
    }

}

