using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communist21 : CardEvent
{
    public Communist21()
    {
        DaysToPlay = 2;
        Name = "Vodka? Cool!";
        Description = "After countless new recipes, the new religion in town has made a drinkable discovery, they've called it vodka!"+""
        + " It makes people care less about the consequences of their actions. They seem more happy in some way but they've been a lot more reckless. ";
        addChoice(new Choice(100,-10,0,"Let's repair the damage", () =>
        {
            return false;
        }));

    }
    
}
