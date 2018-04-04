﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tortuga2 : MonoBehaviour {
    //menos vida al personaje mario
    NoReinicio vidaex;
    public static int valorVida = 1;
    mario2 Vida;
    //Score
    Scores Scoress;
    public static int valorScore = 50;
    //movimiento
    public float posicionInicial;
    public float movimiento = 1f;
    public float veltortuga;
    public bool mirandoDer = true;
    Animator animator;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        Vida = GameObject.Find("mario2").GetComponent<mario2>();
        Scoress = GameObject.Find("Score").GetComponent<Scores>();
        vidaex = GameObject.Find("Vida").GetComponent<NoReinicio>();
        animator = GetComponent<Animator>();
        posicionInicial = this.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
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
        mario2 muerte = collider.gameObject.GetComponent<mario2>();


        if (muerte)
        {
            Destroy(gameObject);
            vidaex.menVida(valorVida);
            Vida.menVida(valorVida);
            Scoress.Score(valorScore);


        }
    }
}