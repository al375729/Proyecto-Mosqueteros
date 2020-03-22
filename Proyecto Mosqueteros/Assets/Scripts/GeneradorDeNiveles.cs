using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GeneradorDeNiveles : MonoBehaviour
{

    private int nivel = 0;
    private int dimension = 30;
    public GameObject sala;
    public GameObject sala3P;
    public GameObject sala2PJuntas;
    public GameObject sala2PSeparadas;
    public GameObject sala1P;
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
                    if (i + 1 < dimension && matriz[i + 1, j] == 1 && j + 1 < dimension && matriz[i + 1, j] == 1 && i - 1 > 0 && matriz[i + 1, j] == 1 && j - 1 > dimension && matriz[i + 1, j] == 1)//Si la sala esta rodeada por otras
                    {
                        Instantiate(sala, new Vector3(i * 90.0f, 0, j * 90.0f), newRotation);
                        //jugador.transform.position = new Vector3(540f,-5f, 540f);}
                    }

                    else if ((i + 1 < dimension && matriz[i + 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)//Si hay una sala arriba , una a la izquierda y una a la derecha
                    {
                        Instantiate(sala3P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 90, 0));
                    }


                    
                     
                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)//Si hay una sala abajo , una a la izquierda y una a la derecha
                    {
                        Instantiate(sala3P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, -90, 0));
                    }


                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1  && j + 1 < dimension && matriz[i, j + 1] == 1)//Si hay una sala a la arriba , una abajo y una a la izquierda
                    {
                        Instantiate(sala3P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 0, 0));
                    }

                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1  && j - 1 > 0 && matriz[i, j - 1] == 1)//Si hay una sala a la arriba , una abajo y una a la derecha
                    {
                        Instantiate(sala3P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 180, 0));
                    }

                     else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1)//Si hay una sala a la arriba y una abajo
                    {
                        Instantiate(sala2PSeparadas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 0, 0));
                    }
                     
                     else if (j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)//Si hay una sala a la derecha y una a la izquierda
                    {
                        Instantiate(sala2PSeparadas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 90, 0));
                    }

                     else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))//Si hay una sala a la derecha y una abajo
                    {
                        Instantiate(sala2PJuntas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 180, 0));
                    }
                    else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))//Si hay una sala a la izquierda y una abajo
                    {
                        Instantiate(sala2PJuntas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, -90, 0));
                    }

                     else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))//Si hay una sala a la izquierda y una arriba
                    {
                        Instantiate(sala2PJuntas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 0, 0));
                    }
                     
                     else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))//Si hay una sala a la arriba y una a la derecha
                    {
                        Instantiate(sala2PJuntas, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, +90, 0));
                    }
                     
                   

                    else if (j + 1 < dimension && matriz[i , j+1] == 1)//Si solo hay una sala a la derecha
                    {
                        Instantiate(sala1P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, -90, 0));
                    }
                    else if (j -1 > 0 && matriz[i, j -1] == 1)//Si solo hay una sala a la izquierda
                    {
                        Instantiate(sala1P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, +90, 0));
                    }
                    else if (i + 1 < dimension && matriz[i +1 , j] == 1)//Si solo hay una sala a arriba
                    {
                        Instantiate(sala1P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 0, 0));
                    }
                    else if (i - 1 > 0 && matriz[i-1, j] == 1)//Si solo hay una sala abajo
                    {
                        Instantiate(sala1P, new Vector3(i * 90.0f, 10f, j * 90.0f), Quaternion.Euler(-90, 180, 0));
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

                        Instantiate(sala, new Vector3(i * 90.0f,200f, j * 90.0f), newRotation);
                        //jugador.transform.position = new Vector3(540f,-5f, 540f);}


                    
                }
            }
        }


    }
}


