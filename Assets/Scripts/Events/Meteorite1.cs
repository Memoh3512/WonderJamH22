using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite1 : CardEvent
{
    public Meteorite1()
    {
        
        Name = "Meteorite emergency!";
        Description = "An apprentice astrophysicist is in panic. Last night he witnessed a devastating meteorite heading directly to our castle! ";

        getChoices.Add(new Choice(800,0,10,"Move the whole castle",()=> {
            GameManager.addPlannedEvent(new Meteorite11());
            return false;
        }));

        getChoices.Add(new Choice(150,0,0,"Shoot a rocket at it?",()=> {
            GameManager.addPlannedEvent(new Meteorite12());
            return false;
        }));
        getChoices.Add(new Choice(0,2,0,"He's dumb, lynch him",()=> {
            return false;
        }));
    }
}
