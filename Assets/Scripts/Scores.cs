using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    public static int score = 0;
    private Text scoreText;

    // Use this for initialization
    void Start()
    {

        scoreText = GetComponent<Text>();
        
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    
}
