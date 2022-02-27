using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomFurry : Kingdom
{
    public KingdomFurry()
    {
        Name = "Furry";
        BaseUnit = new Unit(Resources.Load<Sprite>("Units/FurryF"), 10, 5, 1);
        greediness = 100; // Largeur de la bande
        growth = 75; //50 = moyen + meilleur rendement
        variance = 2.3f; //1.7-2.5
    }
    
}
