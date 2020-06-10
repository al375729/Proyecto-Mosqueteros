using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject pausa;
    public static bool isPaused = false;
    public Button boton;
    public Button boton2;

    void Start()
    {
        Button btnSeguirJugando = boton.GetComponent<Button>();
        Button btnVolver = boton2.GetComponent<Button>();
        btnSeguirJugando.onClick.AddListener(SeguirJugando);
        btnVolver.onClick.AddListener(Volver);

    }
    void Update()
    {
       

        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                DesctivarPausa();
            }
            else
            {
                ActivarPausa();
            }


        }

        

       
    }


    public void ActivarPausa()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pausa.SetActive(true);
       
        isPaused = true;

    }

    public void DesctivarPausa()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pausa.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
    void SeguirJugando()
    {
        DesctivarPausa();
    }

    void Volver()
    {
        SceneManager.LoadScene("Main");       
    }
}
