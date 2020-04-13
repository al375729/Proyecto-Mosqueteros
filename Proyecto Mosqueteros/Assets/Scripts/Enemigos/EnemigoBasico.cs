using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    
  
    public Transform destino;
    private UnityEngine.AI.NavMeshAgent agente;
    private Transform target;
    private GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        target = jugador.GetComponent<Transform>();

        agente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ir();
    }


    void ir()
    {

        Vector3 algo = target.transform.position;
        agente.SetDestination(algo);

    }


}




    

