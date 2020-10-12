using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]
    private int vidaInicial = 5;

    private int vidaActual;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaInicial;
    }

    public void recibeDaño(int daño)
    {
        vidaActual -= daño;

        if (vidaActual <= 0)
            Muere();
    }

    private void Muere()
    {
        gameObject.SetActive(false);
    }
}
