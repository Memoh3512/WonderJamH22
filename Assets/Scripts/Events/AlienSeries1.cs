using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSeries1 : CardEvent
{
  public AlienSeries1()
    {
        
        Weight = 10;
        Name = "Where are the cows?";
        Description = "Multiple occurences of cows mysteriously disapearing have been reported " +
            "all around the kingdom . Farmers are complaining and asking for support from our military.";

        getChoices.Add(new Choice(0,100,0,"Investigate the matter",()=> {
            GameManager.addPlannedEvent(new AlienSeries2());
            return false;
        }));

        getChoices.Add(new Choice(0, 5, 0, "Not our problem", () =>
        {

            return false;
        }));
    }
}
