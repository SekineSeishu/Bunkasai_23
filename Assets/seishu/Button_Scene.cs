using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Scene : MonoBehaviour
{
    public Fade fade;
    public string LoadScene;
    public void onClick()
    {
        //�g�����W�V�������|���ăV�[���J�ڂ���
        fade.FadeIn(1f, () =>
        {
            SceneManager.LoadScene(LoadScene);
            Debug.Log("�{�^����������܂���");
        });
    }
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}