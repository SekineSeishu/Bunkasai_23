using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2_Scene : MonoBehaviour
{
    public string LoadScene;
    public void OnClick()
    {
        SceneManager.LoadScene(LoadScene);
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
