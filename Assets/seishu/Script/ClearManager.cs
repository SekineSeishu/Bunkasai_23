using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    public Text Clear;
    public GameObject Button;
    public GameObject VirtulMouse;
    public GameObject ScoreIcon;
    public GameObject ScoreIconQ;
    public GameObject BGM;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Clear.enabled = false;
        Button.SetActive(false);
        VirtulMouse.SetActive(false);
        ScoreIconQ.SetActive(false);
        ScoreIcon.SetActive(true);
        BGM.SetActive(true);
        Player.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            Clear.enabled = true;
            Button.SetActive(true);
            VirtulMouse.SetActive(true);
            ScoreIcon.SetActive(false);
            ScoreIconQ.SetActive(true);
            BGM.SetActive(false);
            Player.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
