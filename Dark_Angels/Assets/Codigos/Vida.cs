using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]
    private int vidaInicial = 5;

    private int vidaActual;

    public LogicaNPC logicaNPC;

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
       logicaNPC.numObjetivos--;
       logicaNPC.textoMision.text = "Elimina a los demonios" + "\n Restantes: " + logicaNPC.numObjetivos;
          if (logicaNPC.numObjetivos <= 0)
          {
             logicaNPC.textoMision.text = "Misión Completada";
             logicaNPC.botonMision.SetActive(true);
          }
          gameObject.SetActive(false);
    }
}
