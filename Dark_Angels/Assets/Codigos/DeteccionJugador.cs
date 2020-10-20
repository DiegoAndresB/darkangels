using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeteccionJugador : MonoBehaviour
{
    public event Action<Transform> Detectado = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        LogicaDetective detective = other.GetComponent<LogicaDetective>();
        if (detective != null )
        {
            Detectado(detective.transform);
            Debug.Log("detecto");
        }
    }
}
