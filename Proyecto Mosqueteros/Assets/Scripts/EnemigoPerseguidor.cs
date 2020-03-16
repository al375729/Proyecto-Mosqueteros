using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{

    public Transform Player;
    public int MoveSpeed = 40;
    public int MaxDist = 10;
    public int MinDist = 10;




    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}