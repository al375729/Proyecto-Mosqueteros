using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{

    public Transform target;
    Vector3 lookDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = (target.position - transform.position.normalized);
        transform.Translate(lookDirection * Time.deltaTime * speed);

    }
}
