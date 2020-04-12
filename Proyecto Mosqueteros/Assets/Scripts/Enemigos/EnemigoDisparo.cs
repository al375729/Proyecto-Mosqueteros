using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparo : MonoBehaviour
{
 private Transform target ;
    private GameObject jugador;
 public GameObject projectile ;
 public Transform spawn;
 public float maximumLookDistance  = 30;
 public float maximumAttackDistance  = 10;
 public float minimumDistanceFromPlayer  = 2;
    public float bulletSpeed = 200f;

    public float rotationDamping  = 2;
    private bool Shootable = true;
 public float shotInterval = 0.5f;
  
    private GameObject bala;
    public float waitBeforeNextShot = 0.5f;

    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        target = jugador.GetComponent<Transform>();
    }
    void Update()
    {
        float  distance = Vector3.Distance(target.position, transform.position);

        if (distance <= maximumLookDistance)
        {
            LookAtTarget();

            //Check distance and time
            if (distance <= maximumAttackDistance && Shootable)
            {
               

                Shootable = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        Shootable = true;
    }
    void LookAtTarget()
    {

        Vector3 dir =  target.position - transform.position;
        dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }


    void Shoot()
    {
        bala = Instantiate(projectile, spawn.position, spawn.rotation);
        bala.GetComponent<Rigidbody>().velocity = bala.transform.forward * bulletSpeed ;
    }
}
