using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : CardEvent
{
    public Hair()
    {
        
        Name = "Hairdresser";
        Description = "A woman from the village would like to become a hairdresser to help the people who struggle with their style. Is it okay?";

        getChoices.Add(new Choice(10,0,0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("YES","People are happy with their new styles. They even tried to change the natural colors of their hair, what sorcery is this? ","Hihihi"));
            GameManager.addPlannedEvent(new Hair2());
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"No",()=> {
            GameManager.AddEventForToday(new Message("NO","People still have their hair being all disgusting because they don't know how to take care of them. Unfortunately, insects and bugs started to live in the hair of citizens, which started an epidemic. We had to take care of them. ","Of course..."));
            GameManager.playerKingdom.removeKingdomLife(10);
            GameManager.playerKingdom.removeGold(30);
            return false;
        }));
        
    }
}
