using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomPirate : Kingdom
{
    public KingdomPirate()
    {
        Name = "Pirates";
        greediness = 150; // Largeur de la bande
        growth = 70; //50 = moyen + meilleur rendement
        variance = 2.5f; //1.7-2.5
        icon = Resources.Load<Sprite>("Icon/Icon-Pirate");
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
