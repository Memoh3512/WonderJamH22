using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomCowboy : Kingdom
{
    public KingdomCowboy()
    {
        Name = "Cowboy";
        greediness = 100; // Largeur de la bande
        growth = 70; //50 = moyen + meilleur rendement
        variance = 2.4f; //1.7-2.5
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
