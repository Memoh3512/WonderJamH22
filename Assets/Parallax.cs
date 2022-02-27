using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public SpriteRenderer[] layers;
    public SpriteRenderer[] buffers; //Buffers DOIT etre autant d'elements que layers sinon tt va crash
    public float strength = 2f;
    public Vector2 multiplier = Vector2.one;

    public float TransitionDuration = 1f;

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
            buffers[i].transform.position = startPos[i] - strength*displacement * ((i + 1) * multiplier);

        }

    }

    public void TransitionTo(List<Sprite> sprites)
    {

        StartCoroutine(transitionCor(sprites));

    }

    public IEnumerator transitionCor(List<Sprite> newSprites)
    {

        for (int i = 0; i < newSprites.Count; i++)
        {

            buffers[i].sprite = newSprites[i];

        }
        
        float a = 0;
        while (a < 1f)
        {

            for (int i = 0; i < newSprites.Count; i++)
            {

                Color c = buffers[i].color;
                buffers[i].color = new Color(c.r, c.g, c.b,a);

            }

            a += Time.deltaTime/TransitionDuration;
            yield return null;

        }

        for (int i = 0; i < newSprites.Count; i++)
        {

            layers[i].sprite = newSprites[i];
            buffers[i].sprite = null;
            buffers[i].color = Color.white;

        }

    }
    
}
