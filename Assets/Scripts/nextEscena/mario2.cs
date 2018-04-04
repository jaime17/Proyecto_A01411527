using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mario2 : MonoBehaviour {
    NoReinicio vidass;
    public static int vida = 5;
   
    // Use this for initialization
    void Start()
    {

        vidass = GameObject.Find("Vida").GetComponent<NoReinicio>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.LoadLevel("dead");
        }
    }
    void OnTriggerEnter2D(Collider2D collider )
    {
        Caer muerte = collider.gameObject.GetComponent<Caer>();


        if (muerte)
        {
            LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.LoadLevel("level3");
            vidass.menVida(1);
            vida-=1;

        }



    }
    public void menVida(int points)
    {
        vida -= points;
    }
}
