using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    public Text Clear;
    public GameObject VirtulMouse;
    public GameObject ScoreIcon;
    public GameObject ScoreIconQ;
    public GameObject BGM;
    public GameObject Player;
    public Text Rtext;
    public GameObject ScoreInput;
    // Start is called before the first frame update
    void Start()
    {
        Clear.enabled = false;
        VirtulMouse.SetActive(false);
        ScoreIconQ.SetActive(false);
        ScoreIcon.SetActive(true);
        BGM.SetActive(true);
        Player.SetActive(true);
        Rtext.enabled = false;
        ScoreInput.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            Clear.enabled = true;
            VirtulMouse.SetActive(true);
            ScoreIcon.SetActive(false);
            ScoreIconQ.SetActive(true);
            BGM.SetActive(false);
            Player.SetActive(false);
            Rtext.enabled = true;
            ScoreInput.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
