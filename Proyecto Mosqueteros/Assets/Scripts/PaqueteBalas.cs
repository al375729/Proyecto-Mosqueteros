using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaqueteBalas : MonoBehaviour
{
    public GameObject [] modelosPosibles;
    [HideInInspector] public Color [] seleccionColor = {Color.red, Color.blue, Color.white, Color.black, Color.cyan, Color.green, Color.grey, Color.magenta, Color.yellow};
    public float velocidad_min = 100f;
    public float velocidad_max = 300f;

    public int selectBala;
    public int selectPrimerColor;
    public int selectSegundoColor;
    public float velocidadBala;

    Text texto;


    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

        texto = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        texto.text = "CAMBIADO";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            DisparoJugador dp = other.gameObject.GetComponent<DisparoJugador>();

            //Selección del modelo
            GameObject nuevaBala = modelosPosibles[selectBala];
            nuevaBala.layer = 8;
            //Color de la bala
            dp.colorBala = seleccionColor[selectPrimerColor];
            //Segundo color de las partículas
            dp.colorFinalParticulas = seleccionColor[selectSegundoColor];
            //Velocidad de la bala
            dp.bulletSpeed = velocidadBala;

            //Insertar bala en DisparoJugador
            dp.theBullet = nuevaBala;

            
            //Fin
            Destroy(gameObject);
        }
    }
}
