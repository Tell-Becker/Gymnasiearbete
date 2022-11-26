using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public List<SpriteRenderer> rend;
    private List<Color> chosenColors;
    private Color randomColor;

    private void Start()
    {
        // rend = GetComponent<SpriteRenderer>();

        chosenColors = new List<Color>();
        chosenColors.Add(Color.white);
        chosenColors.Add(Color.red);
        chosenColors.Add(Color.cyan);
        chosenColors.Add(Color.green);
        // chosenColors.Add(Color.pink);
        chosenColors.Add(Color.yellow);
        chosenColors.Add(Color.magenta);
        chosenColors.Add(new Color32(255,165,0,255));
        chosenColors.Add(new Color32(255,72,196,255));

        // chosenColors.Add(Color.HSVToRGB(255,165,0));
        // chosenColors.Add(Color.HSVToRGB(255,192,203));
        // Debug.Log("Hej");       
        randomColor = chosenColors[Random.Range(0,8)];

        rend[0].color = randomColor;

        if (rend.Count > 1)
        {
            rend[1].color = randomColor;
            rend[2].color = randomColor;
            rend[3].color = randomColor;
            rend[4].color = randomColor;
            rend[5].color = randomColor;
            rend[6].color = randomColor;
            rend[7].color = randomColor;
            rend[8].color = randomColor;
            rend[9].color = randomColor;
            rend[10].color = randomColor;
            rend[11].color = randomColor;
        }
      
    }

    
}