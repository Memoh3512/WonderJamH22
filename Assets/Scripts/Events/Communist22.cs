using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communist22 : CardEvent
{
    public Communist22()
    {
        DaysToPlay = 2;
        Name = "Off with his head!";
        Description = "The new potato-based religion has been really angry at you about the fact you've not let them have the church. "+""
        + "They've been thinking about how all potatoes are born equal... But not humans? Since then, they've thought about a new societal organisation."
        + "They called it something along the lines of 'Communism'. ";
        addChoice(new Choice(0,20,0,"Nice...", () =>
        {
            return false;
        }));

    }
    
}