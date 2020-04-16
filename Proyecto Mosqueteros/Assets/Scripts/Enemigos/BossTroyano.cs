using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTroyano : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject caballo;
    public float speed = 100f;
    public int vida = 3;
    void Start()
    {
        caballo.GetComponent<Rigidbody>().velocity = caballo.transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        caballo.transform.Rotate(0.0f, 1.0f, 0.0f, Space.Self);
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bala")
        {
            Destroy(other);
            vida--;
            if (vida < 1) { 
                Destroy(this.gameObject);
            }
            

        }
    }
}
