using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomCowboy : Kingdom
{
    public KingdomCowboy()
    {
        Name = "Cowboy";
        BaseUnit = new Unit(Resources.Load<Sprite>("Units/cowboy"), 10, 5, 1);
        greediness = 100; // Largeur de la bande
        growth = 70; //50 = moyen + meilleur rendement
        variance = 2.4f; //1.7-2.5
        icon = Resources.Load<Sprite>("Icon/Icon-Cowboy");
    }

}
