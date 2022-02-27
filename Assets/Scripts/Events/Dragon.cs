using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : CardEvent
{
    public Dragon ()
    {
        
        Name = "Dragon";
        Description = "A local merchant saw a little dragon in a marketplace not far from here.It costs only 20 gold, should we buy it?";

        getChoices.Add(new Choice(20,0,0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("Dragon Bought!","You now have a dragon in your army! Now we need to figure out how to feed it.","OK"));
            Unit dragon = new Unit(Resources.Load<Sprite>("Units/dragon"),40,10,0.6f,5);
            GameManager.playerKingdom.Units.Add(dragon);
            GameManager.addPlannedEvent(new DragonRepeat(dragon));
            return false;
        }));

        getChoices.Add(new Choice(0,1,0,"No",()=> {
            GameManager.AddEventForToday(new Message("Sad merchant","The merchant is sad, but he respect your decision","OK"));
            return false;
        }));
        
    }
}
