using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UniRx;

public class InScene : MonoBehaviour
{
    private SceneInput sceneinput;
    public string LoadScene;//�ړ���V�[���l�[��
    public Fade fade;//�t�F�C�h�C���V�[���ړ�
    private AudioSource audio;//SE�𗬂���
    public AudioClip WaterSE;//�V�[���ړ�����ۂ�SE
    [SerializeField]private bool inFade;//�t�F�C�h�������ăV�[���ړ����邩���f

    private float minInputDuration;//���͂��󂯕t���Ȃ�

    // Start is called before the first frame update
    void Start()
    {
        //���͉\�ɂ���
        audio = gameObject.GetComponent<AudioSource>();
        sceneinput = new SceneInput();
        sceneinput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Observable.EveryAfterUpdate()
            .Where(_ => sceneinput.Player.Scene.triggered)
            .ThrottleFirst(System.TimeSpan.FromSeconds(10f))
            .Subscribe(_ =>
            {
                if (inFade)
                {
                    audio.PlayOneShot(WaterSE);
                    //�g�����W�V�������|���ăV�[���J�ڂ���
                    fade.FadeIn(2f, () =>
                    {
                        SceneManager.LoadScene(LoadScene);
                        Debug.Log("�{�^����������܂���");
                    });
                }
                else
                {
                    SceneManager.LoadScene(LoadScene);
                }
            }).AddTo(this);
    }
}
