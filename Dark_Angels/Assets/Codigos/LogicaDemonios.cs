using UnityEngine;
using UnityEngine.AI;

public class LogicaDemonios : MonoBehaviour
{
    private DeteccionJugador deteccionJugador;
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private Transform objetivo;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        deteccionJugador = GetComponent<DeteccionJugador>();
        deteccionJugador.Detectado += DeteccionJugador_Detectado; ;
    }

    private void DeteccionJugador_Detectado(Transform objetivo)
    {
        this.objetivo = objetivo;
    }

    private void Update()
    {
        if (objetivo != null)
        {
            navMeshAgent.SetDestination(objetivo.position);
            float velX = navMeshAgent.velocity.magnitude;
            anim.SetFloat("VelX", velX);
            anim.SetBool("detecto", true);

            if (navMeshAgent.stoppingDistance == 3)
            {
                anim.SetBool("atacar", true);
            } else
            {
               anim.SetBool("atacar", false);
            }
        }
    }
}
