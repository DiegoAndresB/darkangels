using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaDetective logicaDetective;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "piso")
        {
            logicaDetective.puedoSaltar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        logicaDetective.puedoSaltar = false;
    }
}
