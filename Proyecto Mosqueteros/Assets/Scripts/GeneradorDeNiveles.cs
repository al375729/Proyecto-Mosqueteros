using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GeneradorDeNiveles : MonoBehaviour
{

    private int nivel =0;
    private int dimension = 11;
    public GameObject sala;
    private Quaternion newRotation;
    private int[,] matriz;
    private int numSalas = 10;
    public Transform jugador;




    // Start is called before the first frame update
    void Awake()
    {
      matriz = new int[dimension + nivel, dimension + nivel];
        newRotation = Quaternion.Euler(-90, 0, 0);

       


        for (int i = 0; i < dimension; i += 1)
        {
            for (int j = 0; j < dimension; j += 1)
            {
                matriz[i, j] = 0;
                //print(matriz[i, j]);
            }
        }

        //Instantiate(sala, new Vector3(i * 9.0f, 0, 0), newRotation);

        generate();
    }


    void generate()
    {
        int ran;
        int tamaño = dimension + nivel;
        int medio1 = (int)Math.Round((tamaño / 2) + 0.5);
        int medio2 = medio1;
        int control = 0;
        while (control < numSalas)
        {
            ran = UnityEngine.Random.Range(0, 3);
            matriz[medio1, medio2] = 1;

            if (ran == 0)
            {
                if (medio1 > 0)
                {
                    if (matriz[medio1 - 1, medio2] != 1)
                    {
                        medio1 -= 1;
                        matriz[medio1, medio2] = 1;
                        control += 1;
                        print(control);
                    }
                }
            }

            else if (ran == 1)
            {
                if (medio1 < dimension - 1)
                {
                    if (matriz[medio1 + 1, medio2] != 1)
                    {
                        medio1 += 1;
                        matriz[medio1, medio2] = 1;
                        control += 1;
                        print(control);
                    }
                }
            }

            else if (ran == 2)
            {
                if (medio2 > 0)
                {
                    if (matriz[medio1, medio2 - 1] != 1)
                    {
                        medio2 -= 1;
                        matriz[medio1, medio2] = 1;
                        control += 1;
                        print(control);
                    }
                }
            }

            if (ran == 3)
            {
                if (medio2 < dimension - 1)
                {
                    if (matriz[medio1, medio2 + 1] != 1)
                    {
                        medio2 += 1;
                        matriz[medio1, medio2] = 1;
                        control += 1;
                        //print(control);
                    }
                }
            }
        }

        for (int i = 0; i < dimension; i += 1)
        {
            for (int j = 0; j < dimension; j += 1)
            {
                if (matriz[i, j] == 1)
                {
                   Instantiate(sala, new Vector3(i * 90.0f, 0, j * 90.0f), newRotation);
                    //jugador.transform.position = new Vector3(540f,-5f, 540f);

                }
            }
        }
    }
}


