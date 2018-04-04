using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //movimiento
    public float velx = 0.1f;
    public float movx;
    public float inputx;
    public float salto = 100f;
    public bool mirandoDer;
    //suelo
    public Transform pie;
    public float radiopie;
    public LayerMask suelo;
    public bool enSuelo;
    public bool agachado;

    //animaciones
    Animator animator;
    Rigidbody2D rb;
    public float caida;

    //agarrar caparazon
    public float patada = 500f;
    public Transform mano;
    public float radiomano = 0.09f;
    public LayerMask caprazon;
    public bool agarrar;
    public GameObject caparazon;
    public GameObject mario;
    public float daño = 100f;
    //vida
    public int vida = 5;
    private int valorvida = 1;
    Vida vidass;




    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vidass = GameObject.Find("Vida").GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {//movimiento
        float inputx = Input.GetAxis("Horizontal");



        if (inputx > 0)
        {//Codigo para que el personaje se vaya a la derecha o a la izquierda con 1 derecha, -1 izq
            movx = transform.position.x + (inputx * velx);
            transform.position = new Vector3(movx, transform.position.y, 0);
            transform.localScale = new Vector3(1, 1, 1);


        }
        if (inputx < 0)
        {
            movx = transform.position.x + (inputx * velx);
            transform.position = new Vector3(movx, transform.position.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);


        }


        if (inputx != 0 && enSuelo) //si input no recibe un 0 entonces la animacion corre, si no no xd
        {
            animator.SetFloat("velx", 1);
        }
        else
        {
            animator.SetFloat("velx", 0);
        }

        enSuelo = Physics2D.OverlapCircle(pie.position, radiopie, suelo, 0);
        if (enSuelo) //animacion cuando salta
        {
            animator.SetBool("enSuelo", true);
        }
        else
        {
            animator.SetBool("enSuelo", false);
        }
        if (enSuelo && Input.GetKeyDown(KeyCode.Space)) //salta con espacio y se le agrega una fuerza 
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, salto));
            animator.SetBool("enSuelo", false);
        }

        //agacharse
        if (enSuelo && Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("agachado", true);

        }
        else
        {
            animator.SetBool("agachado", false);

        }

        //mirar
        if (enSuelo && Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("mirarArriba", true);

        }
        else
        {
            animator.SetBool("mirarArriba", false);
        }
        //caida
        caida = rb.velocity.y;
        if (caida != 0 || caida == 0)
        {
            animator.SetFloat("vely", caida);
        }

        //caparazon
        agarrar = Physics2D.OverlapCircle(mano.position, radiomano, caprazon);
        if (agarrar && mirandoDer)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                caparazon.transform.parent = mario.transform;
            }
            else
            {
                caparazon.GetComponent<Rigidbody2D>().AddForce(new Vector2(patada, 0));
            }


        }
        if (vida <= 0)
        {
            Die();
        }


    }// fin del update
     /*void OnTriggerEnter2D(Collider2D collider)
     {
         tortugaVoladora danoo = collider.gameObject.GetComponent<tortugaVoladora>();


         if (danoo)
         {
             vidass.menVida(valorvida);
             vida -= 1;

         }*/




    private void Die()
    {
        LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.LoadLevel("dead");
        Destroy(gameObject);
    }

    public void Vidas(int points)
    {
        vida += points;
    }
    public void menVida(int points)
    {
        vida -= points;
    }
}

