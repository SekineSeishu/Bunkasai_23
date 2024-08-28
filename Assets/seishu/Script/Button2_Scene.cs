using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2_Scene : MonoBehaviour
{
    public string _loadScene;
    public void OnClick()
    {
        SceneManager.LoadScene(_loadScene);
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
