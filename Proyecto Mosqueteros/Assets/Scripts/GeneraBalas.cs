using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraBalas : MonoBehaviour
{
    //Script al cual se insertará la nueva bala
    public DisparoJugador disparoJugador;

    //Vector de modelos posibles
    public GameObject [] modelosPosibles;


    //Material de la bala para cambiarle el color
    public Material materialBala;
    public Color colorBala;

    //Sistema de partículas de la bala
    //public ParticleSystem sistemaParticulas;

    //Velocidad de la bala
    public float velocidadBala;



    // Start is called before the first frame update
    void Start()
    {
        //Obtener script DisparoJugador
        disparoJugador = GetComponent<DisparoJugador>();

        //Para el material
        //rend.sharedMaterial = materialBala;
        //colorBala = materialBala.color;

    }

    // Update is called once per frame
    void Update()
    {
        //Al pulsar "E", se activa el cambio
        if(Input.GetKey(KeyCode.E))
        {
            
            //Selección del modelo
            int seleccion = Random.Range(0, modelosPosibles.Length -1);
            Debug.Log(seleccion);
            GameObject nuevaBala = modelosPosibles[seleccion];


            //Se determina el valor del color, cambiando aleatoriamente
            //el valor H del sistema de color HSV (de 0 a 360)
            //float h_aleatorio = Random.Range(0f, 360f);
            //colorBala = new Color( h_aleatorio, 100f, 100f);
            colorBala = new Color(Random.Range(0,255), 0, 255);

            //Es necesario obteneer el renderer
            Renderer rend = nuevaBala.GetComponent<Renderer>();
            rend.sharedMaterial.SetColor("_Color", colorBala);
            rend.sharedMaterial.SetColor("_EmissionColor", colorBala);


            //Insertar bala generada en DisparoJugador
            disparoJugador.theBullet = nuevaBala;
            
        }
    }
}
