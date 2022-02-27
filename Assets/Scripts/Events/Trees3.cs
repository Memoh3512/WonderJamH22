using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees3 : CardEvent
{
    public Trees3()
    {

        DaysToPlay = 3;
        Name = "Peaceful tree";
        Description = "The green seed grew as a beautiful tree with sumptuous pink flowers. " +
                      "People now come at it to meditate and contemplate its beauty.";
        
        //Choix + cout
        getChoices.Add(new Choice(0, -5, 0, "Peace and love.", () => {
            return false;
        }));

    }
}