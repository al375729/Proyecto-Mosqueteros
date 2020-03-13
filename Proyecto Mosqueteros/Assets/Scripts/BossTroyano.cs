using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTroyano : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject caballo;
    public float speed = 100f;
    void Start()
    {
        caballo.GetComponent<Rigidbody>().velocity = caballo.transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //caballo.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        //caballo.transform.Translate(Time.fixedDeltaTime * speed, 0, Time.fixedDeltaTime * speed);
        
    }


}
