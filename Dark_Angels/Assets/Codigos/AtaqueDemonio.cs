using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDemonio : MonoBehaviour
{
    private float tiempoEntreAtaques = 2.0f;
    private float dañoAtaque = 1.0f;
    public bool jugadorCerca;
    public float timer;

    Animator anim;
    GameObject detective;
    LogicaBarraVida vidaDetective;

    private void Awake()
    {
        detective = GameObject.FindGameObjectWithTag("Player");
        vidaDetective = detective.GetComponent<LogicaBarraVida>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == detective)
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detective)
        {
            jugadorCerca = false;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tiempoEntreAtaques && jugadorCerca)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        timer = 0f;

        if(vidaDetective.vidaActual > 0)
        {
           vidaDetective.vidaActual -= dañoAtaque;
        }
    }
}


