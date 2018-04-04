using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tortugaVoladora : MonoBehaviour
{
    public float posicionInicial;
    public float movimiento = 1f;
    public float veltortuga;
    public bool mirandoDer = true;
    Animator animator;
    Rigidbody2D rb;
    //menos vida al personaje mario
    Vida vidaex;
    private int valorVida = 1;
    Movimiento Vida;
    //Score
    Scores Scoress;
    private int valorScore = 50; 
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        posicionInicial = this.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        vidaex = GameObject.Find("Vida").GetComponent<Vida>();
        Vida = GameObject.Find("Mario").GetComponent<Movimiento>();
        Scoress = GameObject.Find("Score").GetComponent<Scores>();
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
                this.rb.velocity = new Vector3(veltortuga, rb.velocity.x, 0);
                animator.SetBool("vol", true);
                
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
                this.rb.velocity = new Vector3(-veltortuga, rb.velocity.x, 0);
                animator.SetBool("vol", false);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento muerte = collider.gameObject.GetComponent<Movimiento>();


        if (muerte)
        {
            Destroy(gameObject);
            vidaex.menVida(valorVida);
            Vida.menVida(valorVida);
            Scoress.Score(valorScore);


        }
    }
}
