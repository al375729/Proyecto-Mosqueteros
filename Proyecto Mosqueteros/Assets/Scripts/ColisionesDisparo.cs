using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesDisparo : MonoBehaviour
{
    public float contador;
    public int daño = 10;

    public Color colorInicio = Color.white;
    public Color colorFinal = Color.black;
    public GameObject explosion;
    
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
    
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            CrearExplosion();
            Destroy(this.gameObject);
            
        }
    }
    

     void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Stop")
        {
            CrearExplosion();
            Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Enemigo")
        {
            CrearExplosion();
            Destroy(this.gameObject);

        }

    }

    void CrearExplosion()
    {
        GameObject explo = Instantiate(explosion, transform.position, transform.rotation);

        var cambioColor = explo.GetComponent<ParticleSystem>().colorOverLifetime;
        cambioColor.enabled = true;

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(colorInicio, 0.0f), new GradientColorKey(colorFinal, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
        );

        cambioColor.color = new ParticleSystem.MinMaxGradient(gradient);
    }

}
