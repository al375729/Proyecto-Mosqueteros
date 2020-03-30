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
    //public Material materialBala;
    public Color colorBala;
    Color [] seleccionColor = {Color.red, Color.blue, Color.white, Color.black, Color.cyan, Color.green, Color.grey, Color.magenta, Color.yellow};

    //Sistema de partículas de la bala
    public GameObject particulas;
    ParticleSystem sistemaParticulas;

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
            int h_aleatorio = Random.Range(0, seleccionColor.Length);
            //colorBala = new Color( h_aleatorio, 100f, 100f);
            colorBala = seleccionColor[h_aleatorio];

            disparoJugador.colorBala = colorBala;

            //Añadir partículas a la bala
            //sistemaParticulas.main.startColor = colorBala;

            //Insertar bala generada en DisparoJugador
            disparoJugador.theBullet = nuevaBala;
            
        }
    }
}
