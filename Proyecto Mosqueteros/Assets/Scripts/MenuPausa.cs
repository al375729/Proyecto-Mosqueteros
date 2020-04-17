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

    void Start()
    {
        Button btn = boton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

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
    void TaskOnClick()
    {
        DesctivarPausa();
    }
}
