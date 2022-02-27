using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomPirate : Kingdom
{
    public KingdomPirate()
    {
        Name = "Pirates";
        BaseUnit = new Unit(Resources.Load<Sprite>("Units/pieuvre"), 10, 5, 1);
        greediness = 150; // Largeur de la bande
        growth = 70; //50 = moyen + meilleur rendement
        variance = 2.5f; //1.7-2.5
        icon = Resources.Load<Sprite>("Icon/Icon-Pirate");
    }

}
