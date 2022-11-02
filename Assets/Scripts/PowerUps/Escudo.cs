using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public PlayerConttroller ply;
    void Start()
    {
        ply = FindObjectOfType<PlayerConttroller>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        //checar si el objeto entrante es el jugador
        if (_other.tag == "Player")
        {
            ply.escudo = true;
            ply.particle.Play();
        }
        Destroy(gameObject);
    }
}
