using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float moveSpeed;
  

    // Use this for initialization
    void Start()
    {
        moveSpeed = 75f;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime);
       
        
    }

}