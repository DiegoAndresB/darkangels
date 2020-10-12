using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public LogicaDetective jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numObjetivos;
    public GameObject botonMision;

    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = objetivos.Length;
        textoMision.text = "Elimina a los demonios" + "\n Restantes: " + numObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaDetective>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && aceptarMision == false && jugador.puedoSaltar == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            jugadorCerca = true;
            if(aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    public void No()
    {
        jugador.enabled = true;

        panelNPC2.SetActive(false);

        panelNPC.SetActive(true);
    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for(int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}
