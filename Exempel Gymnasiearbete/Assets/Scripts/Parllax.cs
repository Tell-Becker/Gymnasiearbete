using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parllax : MonoBehaviour {

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect; 
    public float offset = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        //Debug.Log(length);
        //Debug.Log(temp);

        if (temp > startpos + (length - 5))
        {
            startpos += length;
        }
        else if (temp < startpos - (length - 5))
        {
            startpos -= length;
        }
    }
}

