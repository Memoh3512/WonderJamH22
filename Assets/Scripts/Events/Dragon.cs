using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : CardEvent
{
    public Dragon ()
    {
        
        Name = "Dragon";
        Description = "A merchant saw a little dragon in a market place no far from here. Should we acquire it?";

        getChoices.Add(new Choice(0, 0, 0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("YES","There are advantages and disadvantages","OK"));
           GameManager.playerKingdom.removeGold(20);
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"No",()=> {
            GameManager.AddEventForToday(new Message("NO","The merchant is sad, but he respect your decision","OK"));
            return false;
        }));
        
    }
}
