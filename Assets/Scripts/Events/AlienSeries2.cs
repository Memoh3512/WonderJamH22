using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSeries2 : CardEvent
{
    public AlienSeries2()
    {
        DaysToPlay = 2;
        Name = "Odd Sightings";
        Description = "The soldiers investigating the mysterious disparition of cows have sent back report " +
            "stating that while our cattle has stopped vanishing," +
            " odd sightings of flashing lights and metalic discs in the sky have been scaring the population. ";
        getChoices.Add(new Choice(0, 0, 40, "Send more soldier, we'll get to the bottom of this!", () =>
        {
            GameManager.addPlannedEvent(new AlienSeries3());
            return false;
        }));

        getChoices.Add(new Choice(0, 10, -20, "It's better not to get involved, call back the soldiers.", () =>
        {          
            return false;
        }));
    }
}
