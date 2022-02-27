using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees0 : CardEvent
{
    public Trees0()
    {

        DaysToPlay = 2;
        Name = "It died ";
        Description = "The tree you tried to plant died before being mature enough to produce";
        
        //Choix + cout
        getChoices.Add(new Choice(0, 0, 0, "Bummer", () => {
            return false; //
        }));

       
       
    }
}
