using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBasico : MonoBehaviour
{


    private int vidaMax = 30 + GeneradorDeNiveles.nivel * 10;
    public int vidaActual;
    public Vida vida;
    private UnityEngine.AI.NavMeshAgent agente;
    private Transform target;
    private GameObject jugador;
    private float distancia = 40f;
    public float rotationDamping = 2;
    public static bool cambioNivel = false;

    public static int cuentaParaPaquete = 3;
    public GameObject Paquete;

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
        if (cambioNivel)
        {
            cambioNivel = false;
            setVida();
        }

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
            Destroy(other);
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

            cuentaParaPaquete--;
            //Debug.Log(cuentaParaPaquete);
            if(cuentaParaPaquete<=0)
            {
                NuevoPaquete();
                cuentaParaPaquete = 3;
            }
        }
    }

    public void setVida()
    {
        vidaMax += 10;
        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);
        
    }

    public void NuevoPaquete()
    {
        //Debug.Log("Crear nuevo paquete");

        GameObject nuevoPaquete = Instantiate(Paquete, transform.position, transform.rotation);
        PaqueteBalas pb = nuevoPaquete.GetComponent<PaqueteBalas>();

        pb.selectBala =             Random.Range(0, pb.modelosPosibles.Length - 1);
        pb.selectPrimerColor =      Random.Range(0, pb.seleccionColor.Length - 1);
        pb.selectSegundoColor =     Random.Range(0, pb.seleccionColor.Length - 1);
        pb.velocidadBala=           Random.Range(pb.velocidad_min, pb.velocidad_max);



    }

}









