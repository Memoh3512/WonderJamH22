using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite11 : CardEvent
{
    public Meteorite11()
    {
        DaysToPlay = 2;
        Name = "Meteorite failure!";
        Description = "The magician of the village was paid a hefty price to move the caste! On the other hand, it doesn't seem that the meteorite actually existed in the first place.";

        getChoices.Add(new Choice(0,0,-10,"Good investment",()=> {
            return false;
        }));
    }
}
