using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDetective : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    //cambio de collider:
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    

    public Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;
    public float velocidadApuntando;

    public bool estoyAtacando;
    public bool estoyApuntando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        velocidadApuntando = velocidadMovimiento * 0.5f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if(!estoyAtacando || !estoyApuntando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if(avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Q) && puedoSaltar && !estoyAtacando)
        {
            anim.SetTrigger("golpeo");
            estoyAtacando = true;
        }

        if (Input.GetKey(KeyCode.Mouse1) && puedoSaltar && !estoyAtacando)
        {
            anim.SetBool("apuntando", true);
            velocidadMovimiento = velocidadApuntando;
            estoyApuntando = true;

        } else
        {
            anim.SetBool("apuntando", false);
            velocidadMovimiento = velocidadInicial;
            estoyApuntando = false;
        }
 
        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);

        if(puedoSaltar)
        {
            if (!estoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("agachado", true);
                    velocidadMovimiento = velocidadAgachado;

                    //cambio de collider:
                    colAgachado.enabled = true;
                    colParado.enabled = false;

                    cabeza.SetActive(true);
                    estoyAgachado = true;
                }

                else
                {
                    if(logicaCabeza.contadorColision <= 0)
                    {
                        anim.SetBool("agachado", false);
                        velocidadMovimiento = velocidadInicial;

                        //cambio de collider:
                        cabeza.SetActive(false);
                        colAgachado.enabled = false;
                        colParado.enabled = true;
                        estoyAgachado = false;
                    }
                }
            }
          
            anim.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("salte", false);
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}
