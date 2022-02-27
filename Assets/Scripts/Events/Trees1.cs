using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees1 : CardEvent
{
    public Trees1()
    {

        DaysToPlay = 3;
        Name = "Money tree!";
        Description = "The yellow seed grew as a shining tree with golden leaves!" +
                      " We are rich!";
        
        //Choix + cout
        getChoices.Add(new Choice(-20, 0, 0, "Go harvest it!", () => {
            GameManager.addPlannedEvent( new Trees1() );
            return false; //
        }));

       
       
    }
}