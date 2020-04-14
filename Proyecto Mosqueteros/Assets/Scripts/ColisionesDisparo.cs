using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesDisparo : MonoBehaviour
{
    public float contador;
    public int daño = 10;
    
    void Awake()
    {
        contador = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        contador -= Time.deltaTime;
        if(contador <= 0)
            Destroy(this.gameObject);
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
