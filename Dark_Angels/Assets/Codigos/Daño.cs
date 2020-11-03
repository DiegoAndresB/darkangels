using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public LogicaBarraVida vidaDetective;
    public LogicaBarraVida vidaDemonio;

    public float daño = 1.0f;
    public float curar = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vidaDetective.vidaActual -= daño;
            vidaDemonio.vidaActual   -= daño;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            vidaDetective.vidaActual += curar;
        }
    }
}
