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

        //�R���|�[�l���g�̃C���X�^���X��߂܂���
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

        // �L�����N�^�[�̈ړ��A�j���[�V�����𐧌䂷��
        bool isMoving = movementValue.magnitude > 0.1f;
        anim.SetBool("isMove", isMoving);

        // �L�����N�^�[�̌����𐧌䂷��
        if (movementValue.x < 0) // �������ւ̈ړ�
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        else if (movementValue.x > 0) // �E�����ւ̈ړ�
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

    }
}
