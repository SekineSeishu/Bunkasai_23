using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InScene : MonoBehaviour
{
    private SceneInput sceneinput;
    public string LoadScene;
    public Fade fade;
    private AudioSource audio;
    public AudioClip WaterSE;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        sceneinput = new SceneInput();
        sceneinput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneinput.Player.Scene.triggered)
        {
            audio.PlayOneShot(WaterSE);
            //トランジションを掛けてシーン遷移する
            fade.FadeIn(2f, () =>
            {
                SceneManager.LoadScene(LoadScene);
                Debug.Log("ボタンが押されました");
            });
        }
    }
}
