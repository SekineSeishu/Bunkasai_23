using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 0.03f;
    [SerializeField] private float setSpeed;
    [SerializeField] public float playerSlowSpeed = 0.01f; // プレイヤーの遅いスピード

    //private float originalSpeed; // プレイヤーの元の速度を保存する変数
    private Vector2 movementValue;
    public InputAction inputMover;
    private Animator anim = null;
    private void OnEnable()
    {
        inputMover.Enable();
    }
    private void OnDisable()
    {
        inputMover.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        // プレイヤーの元の速度を保存
        //originalSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        movementValue = inputMover.ReadValue<Vector2>();
        transform.Translate(
            movementValue.x * Speed,
            movementValue.y * Speed,
            0.0f
            );

        // キャラクターの移動アニメーションを制御する
        bool isMoving = movementValue.magnitude > 0.1f;
        anim.SetBool("isMove", isMoving);

        // キャラクターの向きを制御する
        if (movementValue.x < 0) // 左方向への移動
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementValue.x > 0) // 右方向への移動
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    /* 敵に当たった時に時間を遅くする処理を追加
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 時間を遅くする効果のスクリプトを持つオブジェクトを取得し、そのスクリプトを実行する
            Damege timeSlowEffect = FindObjectOfType<Damege>();
            if (timeSlowEffect != null)
            {
                timeSlowEffect.TriggerTimeSlow();

                // プレイヤーの速度を遅くする
                Speed = playerSlowSpeed;
                ResetSpeed();
                Debug.Log("う、動けん！");
            }
        }
    }
     //時間を元に戻す際に速度を元に戻す
    public void ResetSpeed()
    {
        Speed = setSpeed;
        Debug.Log("う、動けん！");
    }*/
}
