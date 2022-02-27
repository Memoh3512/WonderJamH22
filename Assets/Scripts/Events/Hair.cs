using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : CardEvent
{
    public Hair()
    {
        
        Name = "Hairdresser";
        Description = "A woman from the village would like funding to become a hairdresser and help the people who struggle with their style. What do we do?";

        getChoices.Add(new Choice(100,-10,0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("YES","People are happy with their new styles. They even tried to change the natural colors of their hair, what sorcery is this? ","Hihihi"));
            GameManager.addPlannedEvent(new Hair2());
            return false;
        }));

        getChoices.Add(new Choice(0,10,0,"No",()=> {
            GameManager.AddEventForToday(new Message("NO", "People still have their disgusting hair because they don't know how to take care of it. Unfortunately, insects and bugs started to live in the hair of citizens, which started an epidemic we had to take care of. ", "Of course..."));
            return false;
        }));
        
    }
}
