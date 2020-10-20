using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio : MonoBehaviour
{
    [SerializeField]
    private float volverAtacar = 1.5f;

    private DeteccionJugador deteccionJugador;
    private Vida vidaObjetivo;
    private float tiempoAtaque;

    private void Awake()
    {
        deteccionJugador = GetComponent<DeteccionJugador>();
        deteccionJugador.Detectado += DeteccionJugador_Detectado;
    }

    private void DeteccionJugador_Detectado(Transform objetivo)
    {
        Vida vida = objetivo.GetComponent<Vida>();
        if (vida != null)
        {
            vidaObjetivo = vida; 
        }
    }

    private void Update()
    {
        if (vidaObjetivo != null)
        {
            tiempoAtaque += Time.deltaTime;
            if(puedeAtacar())
            {
                Atacar();
            }
        }
    }

    private bool puedeAtacar()
    {
        return tiempoAtaque >= volverAtacar;
    }

    private void Atacar()
    {
        tiempoAtaque = 0;
        vidaObjetivo.recibeDaño(1);
    }
}
