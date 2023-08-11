using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InScene_dontFade : MonoBehaviour
{
    public SceneInput sceneinput;
    public string LoadScene;
    // Start is called before the first frame update
    void Start()
    {
        sceneinput = new SceneInput();
        sceneinput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneinput.Player.Scene.triggered)
        {
            SceneManager.LoadScene(LoadScene);
        }
    }
}
