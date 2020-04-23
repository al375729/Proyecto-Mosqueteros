using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour
{
    public static int vidaMax = 100;
    public static int vidaActual;
    public Vida vida;
    public Image damageImage;
    public float tiempo = 0.5f;
    public Color colorFlash = new Color(1f, 0f, 0f, 0.5f);
    private bool damaged;
    private GameObject player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        vida.setMaxHealth(vidaMax);

        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            recibirDaño(-5);
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

        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("Main");
        }
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
            GeneradorDeNiveles.numeroEnemigos--;

        }

        if (other.gameObject.tag == "Boss")
        {
            recibirDaño(10);
            rb.AddForce(transform.forward * -1.0f);


        }
    }
}
