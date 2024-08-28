using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    private static int _life;//���C�t
    private Text lifetext;//���C�t�\��
    public GameObject lifeManager;
    private Vector3 initialPosition;//���Z�b�g�ʒu
    private static LifeManager instance;
    public static LifeManager Instance { get { return instance; } }

    public int life { get { return _life; } }//���U���g�V�[���Ń��C�t��n��

    [SerializeField] private Text clear;//�N���A�e�L�X�g
    [SerializeField] private Text gameOver;//�Q�[���I�[�o�[�I�u�W�F�N�g
    public GameObject player;//�v���C���[
    private AudioSource audio;//SE�𗬂���
    public AudioClip gameOverSE;//�Q�[���I�[�o�[SE
    public AudioClip clearSE;//�Q�[���N���ASE
    public GameObject bgm;//�Q�[��BGM
    public GameObject scoreUI;//�X�R�AUI
    public GameObject closeScoreUI;//���U���g���ɃX�R�A���B���ۂ̉B��UI
    public Text resultText;
    public GameObject sceneInput;
    private void Awake()
    {
        initialPosition = transform.position;//�ۑ�
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(lifeManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        _life = 5;//�������C�t

        //�Q�[���v���C��Ԃɂ���i�������j
        audio = gameObject.GetComponent<AudioSource>();
        clear.enabled = false;
        gameOver.enabled = false;
        player.SetActive(true);
        bgm.SetActive(true);
        scoreUI.SetActive(true);
        closeScoreUI.SetActive(false);
        resultText.enabled = false;
        sceneInput.SetActive(false);

        lifetext = GameObject.Find("Life").GetComponent<Text>();
        SetLifeText(_life);
    }

    //���C�t��\��
    private void SetLifeText(int life)
    {
        lifetext.text = "�~" + life.ToString();
    }
    //���C�t�����ƌ�����������UI���X�V
    public void PullLife(int lifePoint)
    {
        _life -= lifePoint;
        SetLifeText(_life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            //�N���A�e�L�X�g�ƃ��U���g��ʂ�\��
            clear.enabled = true;
            audio.PlayOneShot(clearSE);
            Result();
        }
    }

    //���U���gUI
    public void Result()
    {
        player.SetActive(false);//�v���C���[����ʂ������
        bgm.SetActive(false);//�Q�[��BGM���~�߂�
        scoreUI.SetActive(false);//�X�R�A�\��������
        closeScoreUI.SetActive(true);//�X�R�A�̕\�����H��UI��\��
        resultText.enabled = true;
        sceneInput.SetActive(true);
    }

    void Update()
    {
        if (_life == 0)
        {
            audio.PlayOneShot(gameOverSE);//�Q�[���I�[�o�[SE
            gameOver.enabled = true;//�Q�[���I�[�o�[�e�L�X�g���o��
            player.SetActive(false);//�v���C���[����ʂ������
            bgm.SetActive(false);//�Q�[��BGM���~�߂�
            scoreUI.SetActive(false);//�X�R�A�\��������
            closeScoreUI.SetActive(true);//�X�R�A�̕\�����H��UI��\��
            resultText.enabled = true;
            sceneInput.SetActive(true);
        }
        //SceneManager�̖��O���^�C�g���̏ꍇ��ScoreManager��j��
        if (SceneManager.GetActiveScene().name == "titol")
        {
            Destroy(lifeManager);
        }
    }

}

