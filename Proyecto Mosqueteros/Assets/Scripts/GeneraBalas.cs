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
    public float velocidad_min = 100f;
    public float velocidad_max = 300f;



    // Start is called before the first frame update
    void Awake()
    {
        //Obtener script DisparoJugador
        disparoJugador = GetComponent<DisparoJugador>();
        Generar();

    }

    // Update is called once per frame
    void Update()
    {
        //Al pulsar "E", se activa el cambio
        if(Input.GetKey(KeyCode.E))
        {
            Generar();
        }
    }

    void Generar()
    {
        
        //Selección del modelo
        int seleccion = Random.Range(0, modelosPosibles.Length -1);
        Debug.Log(seleccion);
        GameObject nuevaBala = modelosPosibles[seleccion];

        //Selección de color de la bala aleatorio
        int h_aleatorio = Random.Range(0, seleccionColor.Length);
        colorBala = seleccionColor[h_aleatorio];
        disparoJugador.colorBala = colorBala;

        //Segundo color aleatorio para las partículas
        int segundoAleatorio = Random.Range(0, seleccionColor.Length);
        disparoJugador.colorFinalParticulas = seleccionColor[segundoAleatorio];

        //Velocidad de la bala
        float velocidadBala = Random.Range(velocidad_min, velocidad_max);
        disparoJugador.bulletSpeed = velocidadBala;

        //Insertar bala generada en DisparoJugador
        disparoJugador.theBullet = nuevaBala;
            
    }
}
