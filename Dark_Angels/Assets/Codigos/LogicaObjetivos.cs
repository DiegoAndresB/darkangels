using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivos : MonoBehaviour
{

    public int numEnemigos;
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMision;

    // Start is called before the first frame update
    void Start()
    {
        numEnemigos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Elimina a los demonios" + "\n Restantes: " + numEnemigos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numEnemigos--;
            textoMision.text = "Elimina a los demonios" + "\n Restantes: " + numEnemigos;

            if (numEnemigos <= 0)
            {
                textoMision.text = "Misión Completada";
                botonDeMision.SetActive(true);
            }
        }   
    }
}
