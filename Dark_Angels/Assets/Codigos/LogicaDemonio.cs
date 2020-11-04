using UnityEngine;

public class LogicaDemonio : MonoBehaviour
{
    private Transform detective;
    public float velocidad = 3f;
    private Animator anim;
    LogicaBarraVida vidaDetective;
    LogicaBarraVida vidaDemonio;
   
    private void Awake()
    {
        detective = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        vidaDetective = GetComponent<LogicaBarraVida>();
        vidaDemonio = GetComponent<LogicaBarraVida>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (vidaDemonio.vidaActual > 0 && vidaDetective.vidaActual > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, detective.transform.position, velocidad * Time.deltaTime);
            transform.forward = detective.position - transform.position;
        }
    }
}
