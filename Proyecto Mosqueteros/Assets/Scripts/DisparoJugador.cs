using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{

    public GameObject theBullet;
    public Transform barrelEnd;

    public int bulletSpeed;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;
    GameObject bullet;

    //Color de la bala (decidido en GeneraBalas)
    public Color colorBala = Color.white;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootAble)
            {
                shootAble = false;
                Shoott();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }
    void Shoott()
    {
        bullet = Instantiate(theBullet, barrelEnd.position, barrelEnd.rotation);
        
        ParametrosGeneraBalas();
        
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;


    }

    void ParametrosGeneraBalas()
    {
        //Es necesario obteneer el renderer
        Renderer rend = bullet.GetComponent<Renderer>();
        rend.material.SetColor("_Color", colorBala);
        rend.material.SetColor("_EmissionColor", colorBala);
    }

    
}