using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage_Effect_System : MonoBehaviour
{
    public GameObject electric_effect;
    //public GameObject damage_effect;
    public GameObject effect_spawn_point;
    void Start()
    {
        electric_effect = (GameObject)Resources.Load("electric_effect");
        //damage_effect = (GameObject)Resources.Load("damage_effect");
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
    }

    void OnCollisionEnter2D(Collision2D Trigger)
    {
        Debug.Log("‹N“®");
        if (Trigger.gameObject.GetComponent<Jellyfish_move>())
        {
            Instantiate(electric_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }
        /*
        if (Trigger.gameObject.GetComponent<Shark_move>())
        {
            Instantiate(damage_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }
        if (Trigger.gameObject.GetComponent<Muraenid_move>())
        {
            Instantiate(damage_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }*/
    }
}
