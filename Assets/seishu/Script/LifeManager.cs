using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    private static int _life;//ライフ
    private Text lifetext;//ライフ表示
    public GameObject lifeManager;
    private Vector3 initialPosition;//リセット位置
    private static LifeManager instance;
    public static LifeManager Instance { get { return instance; } }

    public int life { get { return _life; } }//リザルトシーンでライフを渡す

    [SerializeField] private Text clear;//クリアテキスト
    [SerializeField] private Text gameOver;//ゲームオーバーオブジェクト
    public GameObject player;//プレイヤー
    private AudioSource audio;//SEを流す先
    public AudioClip gameOverSE;//ゲームオーバーSE
    public AudioClip clearSE;//ゲームクリアSE
    public GameObject bgm;//ゲームBGM
    public GameObject scoreUI;//スコアUI
    public GameObject closeScoreUI;//リザルト時にスコアを隠す際の隠しUI
    public Text resultText;
    public GameObject sceneInput;
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
        DontDestroyOnLoad(lifeManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        _life = 5;//初期ライフ

        //ゲームプレイ状態にする（初期化）
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

    //ライフを表示
    private void SetLifeText(int life)
    {
        lifetext.text = "×" + life.ToString();
    }
    //ライフ減少と減少した時にUIを更新
    public void PullLife(int lifePoint)
    {
        _life -= lifePoint;
        SetLifeText(_life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            //クリアテキストとリザルト画面を表示
            clear.enabled = true;
            audio.PlayOneShot(clearSE);
            Result();
        }
    }

    //リザルトUI
    public void Result()
    {
        player.SetActive(false);//プレイヤーを画面から消す
        bgm.SetActive(false);//ゲームBGMを止める
        scoreUI.SetActive(false);//スコア表示を消す
        closeScoreUI.SetActive(true);//スコアの表示が？のUIを表示
        resultText.enabled = true;
        sceneInput.SetActive(true);
    }

    void Update()
    {
        if (_life == 0)
        {
            audio.PlayOneShot(gameOverSE);//ゲームオーバーSE
            gameOver.enabled = true;//ゲームオーバーテキストを出す
            player.SetActive(false);//プレイヤーを画面から消す
            bgm.SetActive(false);//ゲームBGMを止める
            scoreUI.SetActive(false);//スコア表示を消す
            closeScoreUI.SetActive(true);//スコアの表示が？のUIを表示
            resultText.enabled = true;
            sceneInput.SetActive(true);
        }
        //SceneManagerの名前がタイトルの場合にScoreManagerを破棄
        if (SceneManager.GetActiveScene().name == "titol")
        {
            Destroy(lifeManager);
        }
    }

}

