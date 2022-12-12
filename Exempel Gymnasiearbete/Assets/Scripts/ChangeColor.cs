using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ChangeColor : MonoBehaviour
{
    public List<SpriteRenderer> rend;
    private List<Color> chosenColors;
    public Color32 randomColor;
    [SerializeField] RandomObstacle RandomObstacleScript;

    private void Start()
    {
        // // rend = GetComponent<SpriteRenderer>();

        // chosenColors = new List<Color>();
        // chosenColors.Add(Color.white);
        // chosenColors.Add(Color.red);
        // chosenColors.Add(Color.cyan);
        // chosenColors.Add(Color.green);
        // // chosenColors.Add(Color.pink);
        // chosenColors.Add(Color.yellow);
        // chosenColors.Add(Color.magenta);
        // chosenColors.Add(new Color32(255,165,0,255));
        // chosenColors.Add(new Color32(255,72,196,255));

        // // chosenColors.Add(Color.HSVToRGB(255,165,0));
        // // chosenColors.Add(Color.HSVToRGB(255,192,203));
        // // Debug.Log("Hej");       
        // randomColor = chosenColors[Random.Range(0,8)];
        rend[0].color = RandomObstacleScript.randomObstacleColor;

        // // randomColor = RandomObstacleScript.randomObstacleColor;



        if (rend.Count > 1)
        {
            rend[1].color = RandomObstacleScript.randomObstacleColor;
            rend[2].color = RandomObstacleScript.randomObstacleColor;
            rend[3].color = RandomObstacleScript.randomObstacleColor;
            rend[4].color = RandomObstacleScript.randomObstacleColor;
            rend[5].color = RandomObstacleScript.randomObstacleColor;
            rend[6].color = RandomObstacleScript.randomObstacleColor;
            rend[7].color = RandomObstacleScript.randomObstacleColor;
            rend[8].color = RandomObstacleScript.randomObstacleColor;
            rend[9].color = RandomObstacleScript.randomObstacleColor;
            rend[10].color = RandomObstacleScript.randomObstacleColor;
            rend[11].color = RandomObstacleScript.randomObstacleColor;
        }
      
    }

    
}