using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody rigid;
  

    // Use this for initialization
    void Start()
    {
        //moveSpeed = 75f;
        rigid = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime);

       
        
    }

}