using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : CardEvent
{
    public Pigeon()
    {
        
        Name = "What is this flock?";
        Description = "While looking at the clouds to see what shapes he could see in it, our meteorologist saw a loooooooot of pigeons in the sky last week."
        + " What should we do with them? ";

        getChoices.Add(new Choice(00,-20,-15,"Catch them with garlic bread",()=> {
            GameManager.AddEventForToday(new Message("Catch them","You did well, it was actually two enemies villages who were communicating to organize a siege against you."
                + "You intercepted the lasts messages so the war will not happen. And you keep the pigeons to communicate with your allies.","Fine."));
            Kingdom kd = GameManager.aiKingdoms[Random.Range(0, GameManager.aiKingdoms.Count)];
            kd.IncrementRelation();
            return false;
        }));

        getChoices.Add(new Choice(0,-25,0,"Teach them to dance",()=> {
            GameManager.AddEventForToday(new Message("Teach them","Helped by the druids of the forest, they managed to make a beautiful show with all the pigeons."
                + " People said it was out of the ordinary and wonderful. ","What a show!"));
            return false;
        }));
        
        getChoices.Add(new Choice(0,0,0,"Let them be, they are free",()=> {
            GameManager.addPlannedEvent(new Pigeon2());
            return false;
        }));
    }
}
