using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    Vida vidaex;
    private int valorVida = 1;
    Movimiento masVida;
    
     
 
    // Use this for initialization
    void Start()
    {
        vidaex = GameObject.Find("Vida").GetComponent<Vida>();
        masVida = GameObject.Find("Mario").GetComponent<Movimiento>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento muerte = collider.gameObject.GetComponent<Movimiento>();


        if (muerte)
        {
            Destroy(gameObject);
            vidaex.Vidas(valorVida);
            masVida.Vidas(valorVida);

        }
    }
}
