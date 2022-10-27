using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpawnEnemies : MonoBehaviour
{
    [Header("Limites en Y")]
    public float minY;
    public float maxY;

    [Header("Asignacion de enemigos")]
    public GameObject obstacle;//arreglos de asteroides
    
    [Header("Timer de Generacion")]
    public float timer = 2f;//tiempo de aparicion de enemigos
    private void Start()
    {
        //invocacion de funcion para generar enemigos
        //estos aparecen al inicio del juego
        Invoke("Spawner", timer);
    }

    //metodo para generar enemigos
    void Spawner()
    {
        //vamos a crear una posicion local aleatoria tomando en cuenta los limites de y
        float _posY = Random.Range(transform .position.x + minY, transform.position.x + maxY);

        //valor local que guarda la posicion del generador
        Vector3 _temp = transform.position;

        //igualar la posicion temporal en y con la posicion local en y
        _temp.x = _posY;

            Instantiate(obstacle, _temp, Quaternion.identity);
        //invocacion de funcion para generar enemigos usando un temporizador
        Invoke("Spawner", timer);
    }
}
