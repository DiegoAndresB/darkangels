using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public static int puntos;

    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Puntos: " + puntos;  
    }
}
