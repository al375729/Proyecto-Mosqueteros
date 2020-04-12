using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    
  
    public Transform destino;
    private UnityEngine.AI.NavMeshAgent agente;
   
    // Start is called before the first frame update
    void Start()
    {

        agente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        ir();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ir()
    {

        Vector3 algo = destino.transform.position;
        agente.SetDestination(algo);

    }
}




    

