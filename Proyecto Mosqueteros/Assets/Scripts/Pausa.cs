using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;
    public bool isPaused;
    public Button btn;

    void Start()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

        //if (Input.GetKeyDown(KeyCode.Space))


        if (Input.GetKeyDown(KeyCode.Space)) { 
            isPaused = !isPaused;
            SceneManager.LoadScene("Main");
        }

        if (isPaused) {
            ActivarPausa();
        }
        else 
        {
            DesctivarPausa();
        }
        
        btn.onClick.AddListener(Pulsado);
    }

    void Pulsado()
    {
        pausa.SetActive(false);
    }

    void ActivarPausa()
    {
        pausa.SetActive(true);

    }

    void DesctivarPausa()
    {
        pausa.SetActive(false);

    }
}

