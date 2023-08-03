using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 0.03f;
    [SerializeField] private float setSpeed;
    [SerializeField] public float playerSlowSpeed = 0.01f; // �v���C���[�̒x���X�s�[�h

    //private float originalSpeed; // �v���C���[�̌��̑��x��ۑ�����ϐ�
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
        // �v���C���[�̌��̑��x��ۑ�
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

        // �L�����N�^�[�̈ړ��A�j���[�V�����𐧌䂷��
        bool isMoving = movementValue.magnitude > 0.1f;
        anim.SetBool("isMove", isMoving);

        // �L�����N�^�[�̌����𐧌䂷��
        if (movementValue.x < 0) // �������ւ̈ړ�
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementValue.x > 0) // �E�����ւ̈ړ�
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
    /* �G�ɓ����������Ɏ��Ԃ�x�����鏈����ǉ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ���Ԃ�x��������ʂ̃X�N���v�g�����I�u�W�F�N�g���擾���A���̃X�N���v�g�����s����
            Damege timeSlowEffect = FindObjectOfType<Damege>();
            if (timeSlowEffect != null)
            {
                timeSlowEffect.TriggerTimeSlow();

                // �v���C���[�̑��x��x������
                Speed = playerSlowSpeed;
                ResetSpeed();
                Debug.Log("���A������I");
            }
        }
    }
     //���Ԃ����ɖ߂��ۂɑ��x�����ɖ߂�
    public void ResetSpeed()
    {
        Speed = setSpeed;
        Debug.Log("���A������I");
    }*/
}