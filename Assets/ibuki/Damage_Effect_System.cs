using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Effect_System : MonoBehaviour
{
    private GameObject electric_effect;
    private GameObject damage_effect;
    private GameObject effect_spawn_point;
    void Start()
    {
        electric_effect = (GameObject)Resources.Load("electric_effect");
        damage_effect = (GameObject)Resources.Load("electric_effect");
        effect_spawn_point = transform.Find("effect_spawn_point").gameObject;
    }

    private void OnTriggerEnter(Collider collider)
    {
        /*
        if (collider.GetComponent<Jelly_System> == "Jelly_System")
        {
            Instantiate(electric_effect, effect_spawn_point.
            transform.position, Quaternion.identity, this.transform);
        }*/
    }
}
