using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees2 : CardEvent
{
    public Trees2()
    {

        DaysToPlay = 3;
        Name = "War tree!";
        Description = "The blue seed grew to a wide bush with fruits that can be used as stimulants. " +
                      " Full of strength!";
        
        //Choix + cout
        getChoices.Add(new Choice(0, 0, -15, "Go harvest it!", () => {
            GameManager.addPlannedEvent( new Trees2() );
            return false;
        }));

       
       
    }
}