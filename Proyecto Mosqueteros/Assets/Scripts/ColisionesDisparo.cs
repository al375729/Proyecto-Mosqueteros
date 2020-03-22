using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesDisparo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            Destroy(this.gameObject);
            
        }
    }
    */

     void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Stop")
        {
            Destroy(this.gameObject);

        }
    }
}
