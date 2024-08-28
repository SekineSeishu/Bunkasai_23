using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UniRx;

public class InScene : MonoBehaviour
{
    private SceneInput sceneinput;
    public string LoadScene;//移動先シーンネーム
    public Fade fade;//フェイドインシーン移動
    private AudioSource audio;//SEを流す先
    public AudioClip WaterSE;//シーン移動する際のSE
    [SerializeField]private bool inFade;//フェイドをかけてシーン移動するか判断

    private float minInputDuration;//入力を受け付けない

    // Start is called before the first frame update
    void Start()
    {
        //入力可能にする
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
                    //トランジションを掛けてシーン遷移する
                    fade.FadeIn(2f, () =>
                    {
                        SceneManager.LoadScene(LoadScene);
                        Debug.Log("ボタンが押されました");
                    });
                }
                else
                {
                    SceneManager.LoadScene(LoadScene);
                }
            }).AddTo(this);
    }
}
