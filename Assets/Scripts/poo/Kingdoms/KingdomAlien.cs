using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomAlien : Kingdom
{
    public KingdomAlien()
    {
        Name = "Alien";
        greediness = 100; // Largeur de la bande
        growth = 65; //50 = moyen + meilleur rendement
        variance = 2; //1.7-2.5
        icon = Resources.Load<Sprite>("Icon/Icon-Alien");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
