using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMax =100;
    public int vidaActual;
    public Vida vida;
    public Image damageImage;
    public float tiempo = 0.5f;
    public Color colorFlash = new Color(1f,0f,0f,0.5f);
    private bool damaged;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            recibirDaño(5);
        }
        if (damaged)
        {
            damageImage.color = colorFlash;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, tiempo * Time.deltaTime);
        }
        damaged = false;
    }

    void recibirDaño(int daño)
    {
        damaged = true;
        vidaActual -= daño;
        vida.setHealth(vidaActual);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BalaEnemigo")
        {
            recibirDaño(5);
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Enemigo")
        {
            recibirDaño(5);
            Destroy(other.gameObject);

        }
    }
}
