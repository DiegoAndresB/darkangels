using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDemonios : MonoBehaviour
{
    public LogicaNPC logicaNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            logicaNPC.numObjetivos--;
            logicaNPC.textoMision.text = "Elimina a los demonios" + "\n Restantes: " + logicaNPC.numObjetivos;
            if(logicaNPC.numObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "Misión Completada";
                logicaNPC.botonMision.SetActive(true);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
