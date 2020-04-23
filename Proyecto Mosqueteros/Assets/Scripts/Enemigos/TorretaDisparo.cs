using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaDisparo : MonoBehaviour
{
    private Transform target ;
    private GameObject jugador;

    public GameObject projectile ;
    private Transform spawn;
    public float maximumLookDistance  = 30;
    public float maximumAttackDistance  = 10;
    public float minimumDistanceFromPlayer  = 2;
    public float bulletSpeed = 200f;

    public float rotationDamping  = 2;
    private bool Shootable = true;
    public float shotInterval = 0.5f;
  
    private GameObject bala;
    public float waitBeforeNextShot = 0.5f;

    private Transform cannon;
    float lockPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        target = jugador.GetComponent<Transform>();

        cannon = this.transform.GetChild(0);
        spawn = this.transform.GetChild(0).GetChild(0);
    }

    // Update is called once per frame
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
        //dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir);

        //Rotación del soporte, en el eje y
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);

        //Rotación del cañón, en el eje x
        cannon.rotation = Quaternion.Slerp(cannon.rotation, rotation, Time.deltaTime * rotationDamping);
        cannon.rotation = Quaternion.Euler(cannon.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lockPos);

    }


    void Shoot()
    {
        bala = Instantiate(projectile, spawn.position, spawn.rotation);
        bala.GetComponent<Rigidbody>().velocity = bala.transform.forward * bulletSpeed ;
    }
}
