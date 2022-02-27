using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communist1 : CardEvent
{
    public Communist1()
    {
        
        Weight = 3;
        Name = "Religion founded";
        Description = "A group of peasants would like to buy the abandoned church, as they just have founded a new religion!  " +
        "They have found a special connection with potatoes! They seem to whisper good cooking recipes. ";

        getChoices.Add(new Choice(100,0,0,"Let them have the church",()=> {
            GameManager.addPlannedEvent(new Communist21());
            return false;
        }));

        getChoices.Add(new Choice(0, 5, 0, "That's my church", () =>
        {
            GameManager.addPlannedEvent(new Communist22());
            return false;
        }));
    }
}

