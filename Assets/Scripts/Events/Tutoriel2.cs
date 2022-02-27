using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoriel2 : CardEvent
{
    public Tutoriel2()
    {
        
        Name = "Money and neighboors";
        Description = "1. On your left ou have your stats. They are very important. Try not to get them too low or your kingdom will fall! "
        + "\n2. On your right, it shows the opinion of other kingdoms about you. Try not to anger them too much!";

        getChoices.Add(new Choice(0,0,0,"Hell yea!",()=>
        {
            GameManager.AddEventForToday(new Message("Contract accepted","Prepare yourself, you have a kingdom to manage.","I'm ready!"));

            return false;
        }));
    }
}
