using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {
    public Transform mario;
    public float minX;
    public float maxX;
    public  float minY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position= new Vector3(
            Mathf.Clamp(mario.position.x,minX,maxX),
            Mathf.Clamp(mario.position.y,minY,mario.position.y),
        -10);
	}
}
