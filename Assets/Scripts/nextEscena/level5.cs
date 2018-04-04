using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5 : MonoBehaviour {
    Movimiento nextlevel;
    // Use this for initialization
    void Start()
    {
        nextlevel = GameObject.Find("Mario").GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Movimiento nextLevel = collider.gameObject.GetComponent<Movimiento>();


        if (nextLevel)
        {
            LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.LoadLevel("level5");


        }
    }
}
