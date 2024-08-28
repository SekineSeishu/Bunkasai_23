using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //�^�C�g���ƃ��U���g��ʂ̈ړ�����w�i
    public Transform respawnPosition; // ���X�|�[���ʒu
    public float moveSpeed = 5f; // �J�����̈ړ��X�s�[�h

    private Vector3 originalPosition; // �����ʒu

    // Start is called before the first frame update
    void Start()
    {
        // �����ʒu�Ɉړ�
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �ڕW�ʒu�Ɉړ�
        if (transform.position != respawnPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, respawnPosition.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // �ڕW�ʒu�ɓ��B�����烊�X�|�[��
            Respawn();
        }
    }
    private void Respawn()
    {
        /// ���X�|�[�������������ɋL�q
        // �J�����̈ʒu�������ʒu�ɖ߂�
        transform.position = originalPosition;
    }

}

