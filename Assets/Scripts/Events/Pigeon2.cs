using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pigeon2 : CardEvent
{
    public Pigeon2()
    {
        DaysToPlay = 2;
        Name = "Siege!";
        Description = "What are these catapults and tons of soldiers over the hills there? "
        + "Unfortunately, the pigeons from lasts days were actually twos enemy villages who were communicating to organize an attack against you. "
        + "Prepare your troops, it is time to fight! ";

        getChoices.Add(new Choice(0,-0,-0,"Should've killed those pigeons...",()=> {
            GameManager.AddEventForToday(new WarCounselor(10,-10));
            Kingdom k = GameManager.aiKingdoms.FirstOrDefault(i => i.Name == "Furry");
            GameManager.fightOpponent = k ?? GameManager.aiKingdoms[0];
            return true;
        }));
    }
    
}
