using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalEnemies : MonoBehaviour
{
    [Header("Velocidades de Enemigo")]
    public float speed = 5f; //velocidad del enemigo

    [Header("Limite de Enemigo")]
    private float boundX; //Limite de avance de enemigo en x

    public PlayerConttroller ply;

    void Start()
    {
        boundX = transform.position.y;
        ply = FindObjectOfType<PlayerConttroller>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        Vector3 _temp = transform.position;

        _temp.y -= speed * Time.deltaTime;

        transform.position = _temp;
        
        if (_temp.y <  boundX - 8)
        {
         //destruir al gameobject que tiene este script
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        //checar si el objeto entrante es el jugador
        if (_other.tag == "Player" && ply.escudo == false)
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (ply.escudo == true)
        {
            ply.escudo = false;
        }
        Destroy(gameObject);
    }
}
