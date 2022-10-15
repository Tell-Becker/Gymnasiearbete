using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public Transform player;
    public TextMeshProUGUI scoreText;
    public float newScore;
    // Update is called once per frame
    void Update()
    {

        if (player.position.x < 0 && newScore < 0) 
        {
            scoreText.text = "0";
            newScore = player.position.x;
        }
        else if(newScore < player.position.x )
        {
            scoreText.text = player.position.x.ToString("0");
            newScore = player.position.x;
        }

    }
}