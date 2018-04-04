using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortuga : MonoBehaviour
{
    public float posicionInicial;
    public float movimiento = 1f;
    public float veltortuga;
    public bool mirandoDer = true;
    Animator animator;
    Rigidbody2D rb;
    Scores Scoress;
    public int valorScore = 100;
    Vida Vidass;

  


    // Use this for initialization
    void Start()
    {
        Vidass = GameObject.Find("Vida").GetComponent<Vida>();
        Scoress = GameObject.Find("Score").GetComponent<Scores>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (mirandoDer) // codigo para que se mueva de derecha a izquierda
        {
            if (this.transform.position.x > posicionInicial + movimiento)
            {
                mirandoDer = false;
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                this.rb.velocity = new Vector3(veltortuga, rb.velocity.y, 0);
                animator.SetFloat("velx", veltortuga);
            }
        }
        else
        {
            if (this.transform.position.x < posicionInicial - movimiento)
            {
                mirandoDer = true;
                this.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                this.rb.velocity = new Vector3(-veltortuga, rb.velocity.y, 0);
                animator.SetFloat("velx", veltortuga);
            }
        }

        /* if (Mario.gameObject.GetComponent<Movimiento>().enSuelo == false)
         {
             Movimiento mario = collider.gameObject.GetComponent<Movimiento>();
         }*/
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento muerte = collider.gameObject.GetComponent<Movimiento>();


        if (muerte)
        {
            Destroy(gameObject);
            Scoress.Score(valorScore);
            
        }


    }
}
