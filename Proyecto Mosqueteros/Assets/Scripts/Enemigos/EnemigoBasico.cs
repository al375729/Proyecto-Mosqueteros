using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBasico : MonoBehaviour
{


    public int vidaMax = 30;
    public int vidaActual;
    public Vida vida;
    private UnityEngine.AI.NavMeshAgent agente;
    private Transform target;
    private GameObject jugador;
    private float distancia = 40f;
    public float rotationDamping = 2;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        target = jugador.GetComponent<Transform>();

        agente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= distancia)
        {
            LookAtTarget();
            ir();
        }

    }


    void ir()
    {

        Vector3 algo = target.transform.position;
        agente.SetDestination(algo);

    }

    void LookAtTarget()
    {

        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bala")
        {
            
            recibirDaño(10);

        }
    }

    void recibirDaño(int daño)
    {
        vidaActual -= daño;
        vida.setHealth(vidaActual);

        if (vidaActual == 0)
        {
            Destroy(this.gameObject);
            GeneradorDeNiveles.numeroEnemigos--;
        }
    }
    public static void actualizarVida() { 
    
    }
    
}







