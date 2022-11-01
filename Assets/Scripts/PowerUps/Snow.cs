using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
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
            ply.upVelocity /= 2.0f;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("outSnow", 5);
        }
        Destroy(gameObject, 5);
    }

    void outSnow()
    {
        ply.upVelocity *= 2.0f;
    }
}
