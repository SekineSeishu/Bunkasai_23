using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.FadeOut(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
