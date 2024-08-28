using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimeManager : MonoBehaviour
{
    //Time.timeScale�ɐݒ肷��l
    [SerializeField] private float timeScale = 0.1f;
    //���Ԃ�x�����Ă��鎞��
    [SerializeField] private float slowTime = 1f;
    //�o�ߎ���
    private float elapsedTime = 0f;
    //���Ԃ�x�����Ă��邩�ǂ���
    private bool isSlowDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X���[�_�E���t���O��true�̎��͎��Ԍv��
        if (isSlowDown)
        {
            elapsedTime += Time.unscaledDeltaTime;
            if (elapsedTime >= slowTime)
            {
                SetNormalTime();
            }
        }
    }
    //���Ԃ�x�点�鏈��
    public void SlowDown()
    {
        elapsedTime = 0f;
        Time.timeScale = 0f;
        Time.timeScale = timeScale;
    }
    //���Ԃ����ɖ߂�����
    public void SetNormalTime()
    {
        Time.timeScale = 1f;
        isSlowDown = false;
    }
}
