using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnaval : CardEvent
{
  public Carnaval()
    {
        Name = "Furry Kingdom Carnaval";
        Description = "In three days, as one of their traditions, the Furries people are organizing a colorful carnival. " +
            "Only on this special date, any citizen of any kingdom can come, regardless of what your relationship with them is. " +
            "You are invited to be part of the carriage parade in the Main Street. What kind of carriage would you like to show off?";

        getChoices.Add(new Choice(0, 0, 10, "A tank. Full of soldiers.", () => {
            GameManager.addPlannedEvent(new Message("Carnaval's result", "The tank was not " +
                "at all in the vibe of the carnival. The others nations didn't like it. Soldiers never were so humiliated. They quit.", "NOOOO", () => {
                    foreach (Kingdom k in GameManager.aiKingdoms)
                    {
                        k.DecrementRelation();
                    }
                    return false;
                },3));
            return false;
        }));

        getChoices.Add(new Choice(0, 0, 0, "A rainbow horse-drawn carriage", () =>
        {
            GameManager.addPlannedEvent(new Message("Carnaval's result", "The rainbow horse drawn carriage is a classic choice, but it worked. Moreover, the Cowboys said they liked it very much.", "Okay", () =>
            {
                foreach(Kingdom k in GameManager.aiKingdoms)
                {
                    if (k.Name == "Cowboy")
                    {
                        k.IncrementRelation();
                        break;
                    }
                }
                return false;
            }, 3));
            return false;
        }));



    }


    public override void drawEvent()
    {
        foreach (Kingdom k in GameManager.aiKingdoms)
        {
            if (k.Name == "Alien")
            {

                getChoices.Add(new Choice(0, 0, 0, "A platform with our best dancers on it!", () =>
                {
                    GameManager.addPlannedEvent(new Message("Carnaval's result", "Our dancers went wild on the flat, earth shaped platform. The alien civilization was very impressed", "Awesome!", () =>
                    {                      
                            
                                k.IncrementRelation();                                                  
                       
                        return false;
                    }, 3));
                    return false;
                }));

                break;
            }
        }



        base.drawEvent();
    }
}
