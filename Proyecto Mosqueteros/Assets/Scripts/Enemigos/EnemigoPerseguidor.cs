﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{
    private GameObject jugador;
    private Transform Player;
    public int MoveSpeed = 40;
    public int MaxDist = 10;
    public int MinDist = 10;

    private bool Shootable = true;
    private GameObject bala;
    public float shotInterval = 0.5f;
    public GameObject projectile ;
    public float waitBeforeNextShot = 0.5f;
    public Transform spawn;
    public float bulletSpeed = 50f;
    public int vidaMax = 1;
    public int vidaActual;
    public Vida vida;
    public static bool cambioNivel1 = false;
    private Rigidbody rb;


    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        Player = jugador.GetComponent<Transform>();
       

        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);
    }

    void Update()
    {
        transform.LookAt(Player);


           Vector3 mov = transform.forward;
           mov.y = 0.0f;
           transform.position += mov * MoveSpeed * Time.deltaTime;
          

        if (cambioNivel1)
        {
            cambioNivel1 = false;
            setVida();
        }

        if (Shootable)
            {


                Shootable = false;
                StartCoroutine(ShootingYield());
                Shoot();
               
            }

        
    }
    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        Shootable = true;
    }
    void Shoot()
    {
        bala = Instantiate(projectile, spawn.position, spawn.rotation);
        bala.GetComponent<Rigidbody>().velocity = bala.transform.forward * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bala")
        {

            recibirDaño(10);

        }
    }
    void recibirDaño(int daño)
    {
        vidaActual -= daño;
        vida.setHealth(vidaActual);

        if (vidaActual == 0)
        {
            Destroy(this.gameObject);
            GeneradorDeNiveles.siguienteNivel = true;
        }
    }
    public void setVida()
    {
        vidaMax += 20;
        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);
    }
}