using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneradorDeNiveles : MonoBehaviour
{
     private int dimension = 60;

    public GameObject Pruebassssssss;
    public GameObject sala;
    public GameObject sala3P;
    public GameObject sala2PJuntas;
    public GameObject sala2PJuntasB;
    public GameObject sala2PSeparadasA;
    public GameObject sala2PSeparadasB;
    public GameObject sala1PA;
    public GameObject sala1PB;

    public GameObject LuzGeneral;

    //public GameObject sala2;
    //public GameObject sala3P2;
    //public GameObject sala2PJuntas2;
    //public GameObject sala2PSeparadas2;
    //public GameObject sala1P2;

    private Quaternion newRotation;
    private int[,] matriz;
    private int numSalas = 10 + nivel;
    public Transform jugador;

    public  static int numeroEnemigos ;
    public static int nivel = 0;
    public static bool boss = false;
    private List<GameObject> salas = new List<GameObject>();
    private Rigidbody rb;
    public GameObject player;

    public static bool siguienteNivel = false;
    public GameObject calavera;




    // Start is called before the first frame update
    void Awake()
    {
       
        boss = false;
        siguienteNivel = false;
        nivel = 0;
        //LuzGeneral.SetActive(true);

        Instantiate(Pruebassssssss, new Vector3(0f, 0f, 0f), Quaternion.Euler(-90, 0, 0));
        matriz = new int[dimension , dimension ];
        newRotation = Quaternion.Euler(-90, 0, 0);
        rb = player.GetComponent<Rigidbody>();
        



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

    void Update()
    {
        
        if (siguienteNivel)
        {
            siguienteNivel = false;
            nextLevel();        
        }

        if (numeroEnemigos < 1 && boss == false)
        {
            Contadores.mostrar = false;
            boss = true;
            batallaBoss();
        }

    }


    void generate()
    {
        LuzGeneral.SetActive(true);
        numeroEnemigos = 0;

        Contadores.mostrar = true;
        numSalas = 10 + nivel;
        int ran;
        int tamaño = dimension;
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
                    if (i + 1 < dimension && matriz[i + 1, j] == 1 && j + 1 < dimension && matriz[i + 1, j] == 1 && i - 1 > 0 && matriz[i + 1, j] == 1 && j - 1 > dimension && matriz[i + 1, j] == 1)
                    //Si la sala esta rodeada por otras
                    {

                        GameObject uno = (GameObject) Instantiate(sala, new Vector3(i * 90f, 150f, j * 90f), newRotation);
                        salas.Add(uno);

                    }

                    else if ((i + 1 < dimension && matriz[i + 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala arriba , una a la izquierda y una a la derecha
                    {
                        GameObject uno = (GameObject) Instantiate(sala3P, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 0));
                        salas.Add(uno);
                        numeroEnemigos +=3 ;
                        Debug.Log(numeroEnemigos);
                    }




                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala abajo , una a la izquierda y una a la derecha
                    {
                        GameObject uno = (GameObject) Instantiate(sala3P, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, -90, 0));
                        salas.Add(uno);
                        numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                    }


                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala a la arriba , una abajo y una a la izquierda
                    {
                        GameObject uno = (GameObject) Instantiate(sala3P, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 0, 0));
                        salas.Add(uno);
                        numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                    }

                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1 && j - 1 > 0 && matriz[i, j - 1] == 1)
                    //Si hay una sala a la arriba , una abajo y una a la derecha
                    {
                        GameObject uno = (GameObject) Instantiate(sala3P, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 180, 0));
                        salas.Add(uno);
                        numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                    }

                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1)
                    //Si hay una sala a la arriba y una abajo
                    {
                        int probar = UnityEngine.Random.Range(0, 10);
                        if(probar%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PSeparadasA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 0, 0));
                            salas.Add(uno);
                            numeroEnemigos += 4;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PSeparadasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 0, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala a la derecha y una a la izquierda
                    {
                        int probar = UnityEngine.Random.Range(0, 10);
                        if(probar%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PSeparadasA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 0));
                            salas.Add(uno);
                            numeroEnemigos += 4;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PSeparadasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))
                    //Si hay una sala a la derecha y una abajo
                    {
                        int randi = UnityEngine.Random.Range(0, 10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntas, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 270, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 270, -90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }
                    else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))
                    //Si hay una sala a la izquierda y una abajo
                    {
                        int randi = UnityEngine.Random.Range(0, 10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntas, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 0, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 0, -90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }

                    else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))
                    //Si hay una sala a la izquierda y una arriba
                    {
                        int randi = UnityEngine.Random.Range(0, 10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntas, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, -90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))
                    //Si hay una sala a la arriba y una a la derecha
                    {
                        int randi = UnityEngine.Random.Range(0, 10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntas, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 180, 0));
                            salas.Add(uno);
                            numeroEnemigos += 3;
                        Debug.Log(numeroEnemigos);
                        }
                        else 
                        {
                            GameObject uno = (GameObject) Instantiate(sala2PJuntasB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 180, -90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }



                    else if (j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si solo hay una sala a la derecha
                    {
                        int randi = UnityEngine.Random.Range(0,10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, -0, 0));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, -0, 90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }

                    }
                    else if (j - 1 > 0 && matriz[i, j - 1] == 1)
                    //Si solo hay una sala a la izquierda
                    {
                        int randi = UnityEngine.Random.Range(0,10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, +180, 0));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }else
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, +180, 90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }
                    else if (i + 1 < dimension && matriz[i + 1, j] == 1)
                    //Si solo hay una sala a arriba
                    {
                        int randi = UnityEngine.Random.Range(0,10);
                        if(randi%2==0)
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 0));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                        else
                        {
                            GameObject uno = (GameObject) Instantiate(sala1PB, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 90, 90));
                            salas.Add(uno);
                            numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                        }
                    }
                    else if (i - 1 > 0 && matriz[i - 1, j] == 1)
                    //Si solo hay una sala abajo
                    {
                        GameObject uno = (GameObject) Instantiate(sala1PA, new Vector3(i * 90F, 150f, j * 90F), Quaternion.Euler(-90, 270, 0));
                        salas.Add(uno);
                        numeroEnemigos += 2;
                        Debug.Log(numeroEnemigos);
                    }

                }
            }
        }
        jugador.transform.position = new Vector3(2669.8f, 174F, 2685.3f);



        /*

        for (int i = 0; i < dimension; i += 1)
        {
            for (int j = 0; j < dimension; j += 1)
            {
                if (matriz[i, j] == 1)
                {
                    if (i + 1 < dimension && matriz[i + 1, j] == 1 && j + 1 < dimension && matriz[i + 1, j] == 1 && i - 1 > 0 && matriz[i + 1, j] == 1 && j - 1 > dimension && matriz[i + 1, j] == 1)
                    //Si la sala esta rodeada por otras
                    {
                        Instantiate(sala2, new Vector3(i * 180f, 0, j * 180f), newRotation);

                    }

                    else if ((i + 1 < dimension && matriz[i + 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala arriba , una a la izquierda y una a la derecha
                    {
                        Instantiate(sala3P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 90, 0));
                    }




                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala abajo , una a la izquierda y una a la derecha
                    {
                        Instantiate(sala3P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, -90, 0));
                    }


                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala a la arriba , una abajo y una a la izquierda
                    {
                        Instantiate(sala3P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 0, 0));
                    }

                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1 && j - 1 > 0 && matriz[i, j - 1] == 1)
                    //Si hay una sala a la arriba , una abajo y una a la derecha
                    {
                        Instantiate(sala3P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 180, 0));
                    }

                    else if ((i - 1 > 0 && matriz[i - 1, j] == 1) && i + 1 < dimension && matriz[i + 1, j] == 1)
                    //Si hay una sala a la arriba y una abajo
                    {
                        Instantiate(sala2PSeparadas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 0, 0));
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si hay una sala a la derecha y una a la izquierda
                    {
                        Instantiate(sala2PSeparadas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 90, 0));
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))
                    //Si hay una sala a la derecha y una abajo
                    {
                        Instantiate(sala2PJuntas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 180, 0));
                    }
                    else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i - 1 > 0 && matriz[i - 1, j] == 1))
                    //Si hay una sala a la izquierda y una abajo
                    {
                        Instantiate(sala2PJuntas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, -90, 0));
                    }

                    else if (j + 1 < dimension && matriz[i, j + 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))
                    //Si hay una sala a la izquierda y una arriba
                    {
                        Instantiate(sala2PJuntas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 0, 0));
                    }

                    else if (j - 1 > 0 && matriz[i, j - 1] == 1 && (i + 1 < dimension && matriz[i + 1, j] == 1))
                    //Si hay una sala a la arriba y una a la derecha
                    {
                        Instantiate(sala2PJuntas2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, +90, 0));
                    }



                    else if (j + 1 < dimension && matriz[i, j + 1] == 1)
                    //Si solo hay una sala a la derecha
                    {
                        Instantiate(sala1P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, -90, 0));
                    }
                    else if (j - 1 > 0 && matriz[i, j - 1] == 1)
                    //Si solo hay una sala a la izquierda
                    {
                        Instantiate(sala1P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, +90, 0));
                    }
                    else if (i + 1 < dimension && matriz[i + 1, j] == 1)
                    //Si solo hay una sala a arriba
                    {
                        Instantiate(sala1P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 0, 0));
                    }
                    else if (i - 1 > 0 && matriz[i - 1, j] == 1)
                    //Si solo hay una sala abajo
                    {
                        Instantiate(sala1P2, new Vector3(i * 180f, 50f, j * 180f), Quaternion.Euler(-90, 180, 0));
                    }

                }
            }
        }
        */
    }



    void batallaBoss()
    {
        jugador.transform.position = new Vector3(1133f, 89f, -43f);
        Instantiate(calavera, new Vector3(1136f, 92f, 32f), Quaternion.Euler(-90, 180, 0));
        rb.velocity = Vector3.zero;
        LuzGeneral.SetActive(false);
    }

    void nextLevel()
    {
        foreach (GameObject prefab in salas)
        {
            Destroy(prefab);
        }
        salas.Clear();
        for (int i = 0; i < dimension; i += 1)
        {
            for (int j = 0; j < dimension; j += 1)
            {
                matriz[i, j] = 0;
                //print(matriz[i, j]);
            }
        }
        nivel++;
        numSalas = 10 + nivel;
        generate();
        EnemigoBasico.cambioNivel = true;
        EnemigoPerseguidor.cambioNivel1 = true;
       



        boss = false;
    }
}
