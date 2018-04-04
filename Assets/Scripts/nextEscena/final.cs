using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour {
    Movimiento nextlevel;
    // Update is called once per frame
    void Update () {

    }
    
    // Use this for initialization
    void Start()
    {
        nextlevel = GameObject.Find("Mario").GetComponent<Movimiento>();
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento nextLevel = collider.gameObject.GetComponent<Movimiento>();


        if (nextLevel)
        {
            LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.LoadLevel("win");


        }
    }
}

