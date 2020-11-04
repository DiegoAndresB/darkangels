using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public LogicaBarraVida vidaDetective;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaDetective.vidaActual <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
