using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public GameObject panelNPCMision;

    // Start is called before the first frame update
    void Start()
    {   
        simboloMision.SetActive(true);
        panelNPCMision.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
