using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 0.03f;
    //[SerializeField] private float setSpeed;
    //[SerializeField] public float playerSlowSpeed = 0.01f; // プレイヤーの遅いスピード

    //private float originalSpeed; // プレイヤーの元の速度を保存する変数
    private Rigidbody rb;
    private ParticleSystem particles;
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
        rb = this.gameObject.GetComponent<Rigidbody>();
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        particles = GetComponentInChildren<ParticleSystem>(); 
        // 子オブジェクトからParticleSystemコンポーネントを取得
        // プレイヤーの元の速度を保存
        //originalSpeed = Speed;
    }

    private void Update()
    {
        if (rb.velocity != new Vector3(0, 0, 0))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void FixedUpdate()
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
        //キャラクターが移動中軌跡を残す
        if (isMoving)
        {
            //オブジェクトを呼び出す
            if (!particles.isPlaying)
            {
                particles.Play();// キャラクターが動いている場合はParticleを再生する
            }

        }
        else
        {
            if (particles.isPlaying)
            {
                particles.Stop();// キャラクターが動いている場合はParticleを停止する
            }
        }
    }
}
