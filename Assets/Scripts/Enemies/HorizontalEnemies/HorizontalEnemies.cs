using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalEnemies : MonoBehaviour
{
    [Header("Velocidades de Enemigo")]
    public float speed = 5f; //velocidad del enemigo

    [Header("Limite de Enemigo")]
    public float boundX = -10f; //Limite de avance de enemigo en x

    public PlayerConttroller ply;

    void Start()
    {
        ply = FindObjectOfType<PlayerConttroller>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {//start moveEnemy
     //checar si el enemigo se puede mover
     //variable que guarda la posicion actual del enemigo
        Vector3 _temp = transform.position;

        //decremento de la pos x del enemigo usando el tiempo
        _temp.x += speed * Time.deltaTime;

        //actualizar la posicion  de este objeto usando el vector temp
        transform.position = _temp;

        //validar el limite de -x de la posicion del enemigo
        //checar si el valor del _temp en x es menor al valor de limite en x
        if (_temp.x > boundX)
        {//start if2
         //destruir al gameobject que tiene este script
            Destroy(gameObject);
        }//end if2
    }//end moveEnemy

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
