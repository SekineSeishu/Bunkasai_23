using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Scene : MonoBehaviour
{
    public Fade fade;
    private AudioSource audio;
    public AudioClip WaterSE;
    public string LoadScene;
    public void onClick()
    {
        audio.PlayOneShot(WaterSE);
        //トランジションを掛けてシーン遷移する
        fade.FadeIn(2f, () =>
        {
            SceneManager.LoadScene(LoadScene);
            Debug.Log("ボタンが押されました");
        });
    }
        // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
