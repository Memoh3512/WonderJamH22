using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomFurry : Kingdom
{
    public KingdomFurry()
    {
        Name = "Furry";
        greediness = 100; // Largeur de la bande
        growth = 55; //50 = moyen + meilleur rendement
        variance = 2.1f; //1.7-2.5
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
