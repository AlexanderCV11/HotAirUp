using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarEscena : MonoBehaviour
{
    public GameObject backGround;
    private bool activado = false;
    public void onOptions()
    {
        activado = !activado;
        backGround.SetActive(activado);
    }

    public void cambiarEscena( string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
