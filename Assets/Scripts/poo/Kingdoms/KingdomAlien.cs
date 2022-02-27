using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomAlien : Kingdom
{
    public KingdomAlien()
    {
        Name = "Alien";
        BaseUnit = new Unit(Resources.Load<Sprite>("Units/Alien"), 10, 5, 1);
        greediness = 100; // Largeur de la bande
        growth = 65; //50 = moyen + meilleur rendement
        variance = 2; //1.7-2.5
        icon = Resources.Load<Sprite>("Icon/Icon-Alien");
        removeMilitaryPower(-200);
        this.DecrementRelation();
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
