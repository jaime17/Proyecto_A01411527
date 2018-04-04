using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour {
    Scores Scoress;
    private int valorScore = 50;
    // Use this for initialization
    void Start () {
        Scoress = GameObject.Find("Score").GetComponent<Scores>();

    }
	
	// Update is called once per frame
	void Update () {
		
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
