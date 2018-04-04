using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    public static int vida = 5;
    private Text vidaText;
    

    // Use this for initialization
    void Start()
    {

        vidaText = GetComponent<Text>();
        Reset();
        
        vidaText.text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vidas(int points)
    {
        vida += points;
        vidaText.text = vida.ToString();
        
    }
    public void menVida(int points)
    {
        vida -= points;
        vidaText.text = vida.ToString();
    }
    public int getvalor()
    {
        return vida;
    }

   public static void Reset()
    {
        vida = 5;
        
    }
}
