using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 0.5f;
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
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (movementValue.x > 0) // 右方向への移動
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

    }
}
