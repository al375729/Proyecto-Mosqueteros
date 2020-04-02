using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{

    public GameObject theBullet;
    public Transform barrelEnd;

    public float bulletSpeed = 200f;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;
    GameObject bullet;

    //Color de la bala (decidido en GeneraBalas)
    public Color colorBala = Color.white;
    //Sistema de partículas que acompaña a la bala
    public GameObject particulas;
    public Color colorFinalParticulas;

    //Por si es necesario reducir la escala del jugador
    private float adaptarEscala;

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
        
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed * adaptarEscala;


    }

    void ParametrosGeneraBalas()
    {
        //Es necesario obteneer el renderer
        Renderer rend = bullet.GetComponent<Renderer>();
        //Cambiar colores normal y de emisión a la bala
        rend.material.SetColor("_Color", colorBala);
        rend.material.SetColor("_EmissionColor", colorBala);

        //Instanciar partículas de la bala
        GameObject part = Instantiate(particulas, barrelEnd.position, barrelEnd.rotation);
        //Para que el color inicial de las partículas sea el mismo que el de la bala
        // VERSIÓN 1: https://docs.unity3d.com/ScriptReference/ParticleSystem.MainModule-startColor.html
        /*var main = part.GetComponent<ParticleSystem>().main;
        main.startColor = colorBala;*/

        // VERSIÓN 2: https://docs.unity3d.com/ScriptReference/ParticleSystem.ColorOverLifetimeModule-color.html
        var cambioColor = part.GetComponent<ParticleSystem>().colorOverLifetime;
        cambioColor.enabled = true;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(colorBala, 0.0f), new GradientColorKey(colorFinalParticulas, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );

        cambioColor.color = new ParticleSystem.MinMaxGradient(gradient);

        //Añadir objeto de sistema de partículas a la bala
        part.transform.parent = bullet.transform;

        //Por si hay que escalar el jugador para que se adapte al escenario
        //La escala en la scene Pruebas es (5, 5, 5)
        adaptarEscala = transform.localScale.x / 5;
        bullet.transform.localScale =   new Vector3(adaptarEscala, adaptarEscala, adaptarEscala);
        
        part.transform.localScale =     new Vector3(adaptarEscala, adaptarEscala, adaptarEscala);

    }

    
}