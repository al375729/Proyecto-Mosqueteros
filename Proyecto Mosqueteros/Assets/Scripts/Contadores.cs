using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contadores : MonoBehaviour
{
    public Text texto;
    public static bool mostrar = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mostrar) texto.text = "Enemigos restantes:" + GeneradorDeNiveles.numeroEnemigos.ToString();
        else texto.text = "";

    }


}
