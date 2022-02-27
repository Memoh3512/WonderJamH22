using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite12 : CardEvent
{
    public Meteorite12()
    {
        DaysToPlay = 2;
        Name = "Rocket science";
        Description = "The rocket failed miserably, lacking knowledge about science that is not yet discovered. Maybe next time have bigger brains on the project may help a bit "
        + ".The projectile even hurt some townspeople. As the rocket failed, the anxiety among the people grew considerably."
        + " Surprisingly the meteorite never came, I wonder who's to blame?";

        getChoices.Add(new Choice(0,5,0,"That astrophysicist...",()=> {
            return false;
        }));
    }
}
