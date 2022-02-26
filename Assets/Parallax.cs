using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public SpriteRenderer[] layers;
    public float strength = 2f;
    public Vector2 multiplier = Vector2.one;

    private Vector2[] startPos;
    
    // Start is called before the first frame update
    void Start()
    {

        startPos = new Vector2[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            GameObject l = layers[i].gameObject;
            startPos[i] = new Vector2(l.transform.position.x, l.transform.position.y);

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        int screenX = Screen.currentResolution.width;
        int screenY = Screen.currentResolution.height;

        Vector2 center = Vector2.one *0.5f;

        Vector2 displacement =  (Input.mousePosition / new Vector2(screenX, screenY)) - center;

        for (int i = 0; i < layers.Length; i++)
        {

            layers[i].transform.position = startPos[i] - strength*displacement * ((i + 1) * multiplier);

        }
        //allo pénis 8=====D

    }
}
