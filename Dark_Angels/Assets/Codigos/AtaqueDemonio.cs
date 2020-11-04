using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDemonio : MonoBehaviour
{
    private float tiempoEntreAtaques = 2.0f;
    private float dañoAtaque = 1.0f;
    public bool jugadorCerca;
    public float timer;
    public int valorPuntos = 10;

    Animator anim;
    GameObject detective;
    public LogicaBarraVida vidaDetective;
    public LogicaBarraVida vidaDemonio;

    private void Awake()
    {
        detective = GameObject.FindGameObjectWithTag("Player");
        vidaDetective = detective.GetComponent<LogicaBarraVida>();
        vidaDemonio = GetComponent<LogicaBarraVida>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == detective)
        {
            jugadorCerca = true;
            anim.SetBool("atacar", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detective)
        {
            jugadorCerca = false;
            anim.SetBool("atacar", false);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tiempoEntreAtaques && jugadorCerca && vidaDemonio.vidaActual > 0)
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
        } else
        {
            anim.SetBool("parado", true);
        }
    }

    public void recibeDaño()
    {
        timer = 0f;

        if (vidaDemonio.vidaActual > 0)
        {
            vidaDemonio.vidaActual -= dañoAtaque;
        }

        if ( vidaDemonio.vidaActual <= 0)
        {
            Puntos.puntos += valorPuntos;
        }
    }
}


