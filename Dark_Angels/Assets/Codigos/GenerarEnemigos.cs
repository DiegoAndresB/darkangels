using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigos : MonoBehaviour
{ 
    public LogicaBarraVida vidaDetective;
    public GameObject demonio;
    public float tiempoAparicion = 3f;
    public Transform[] puntosAparicion;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Aparicion", tiempoAparicion, tiempoAparicion);    
    }

    // Update is called once per frame
    void Aparicion()
    {
        if(vidaDetective.vidaActual <= 0f)
        {
            return;
        }

        int puntosGeneracion = Random.RandomRange(0, puntosAparicion.Length);

        Instantiate(demonio, puntosAparicion[puntosGeneracion].position, puntosAparicion[puntosGeneracion].rotation);

    }
}
