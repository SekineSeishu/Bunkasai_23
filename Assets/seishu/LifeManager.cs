using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private int Life;
    private Text lifetext;
    public Text GameOver;
    public GameObject Button;
    public GameObject VirtulMouse;
    public GameObject Player;
    private AudioSource audio;
    public AudioClip GameOverSE;
    // Start is called before the first frame update
    void Start()
    {
        Life = 5;
        audio = gameObject.AddComponent<AudioSource>();
        GameOver.enabled = false;
        Button.SetActive(false);
        VirtulMouse.SetActive(false);
        Player.SetActive(true);
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
            GameOver.enabled = true;
            Button.SetActive(true);
            VirtulMouse.SetActive(true);
            Player.SetActive(false);
        }

    }
}
