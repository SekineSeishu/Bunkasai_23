using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private static int Life;
    private Text lifetext;
    public GameObject LManager;
    //リセット用
    private Vector3 initialPosition;
    private static LifeManager instance;
    public static LifeManager Instance { get { return instance; } }

    public int life { get { return Life; } }

    public GameObject GameOver;
    public GameObject VirtulMouse;
    public GameObject Player;
    private AudioSource audio;
    public AudioClip GameOverSE;
    public GameObject BGM;
    public GameObject Score;
    public GameObject ScoreQ;
    public Text Rtext;
    public GameObject ScoreInput;
    private void Awake()
    {
        initialPosition = transform.position;//保存
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(LManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
        audio = gameObject.AddComponent<AudioSource>();
        GameOver.SetActive(false);
        VirtulMouse.SetActive(false);
        Player.SetActive(true);
        BGM.SetActive(true);
        Score.SetActive(true);
        ScoreQ.SetActive(false);
        Rtext.enabled = false;
        ScoreInput.SetActive(false);

        lifetext = GameObject.Find("Life").GetComponent<Text>();
        SetLifeText(Life);
    }
    private void SetLifeText(int life)
    {
        lifetext.text = "×" + life.ToString();
    }
    public void PullLife(int lifePoint)
    {
        Life -= lifePoint;
        SetLifeText(Life);
    }
    // Update is called once per frame
    void Update()
    {
        if (Life == 0)
        {
            //ゲームオーバーSE
            audio.PlayOneShot(GameOverSE);
            GameOver.SetActive(true);
            VirtulMouse.SetActive(true);
            Player.SetActive(false);
            BGM.SetActive(false);
            Score.SetActive(false);
            ScoreQ.SetActive(true);
            Rtext.enabled = true;
            ScoreInput.SetActive(true);
            Life = -1;
            
        }

    }
}
