using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succesor : CardEvent
{
    public Succesor()
    {
        
        Name = "Successor but not heir";
        Description = "There this guy, Reltih who has ideas about politics. These are kinda weird: he says the leader of the village should be chosen by the people leaded. And not by familial succession. He's becoming dangerously followed and agreed with. What should we do?";

        getChoices.Add(new Choice(10,0,0,"Engage a hitman to eliminate him discreetly.",()=> {
            GameManager.AddEventForToday(new Message("Engage a hitman to eliminate him discreetly.","People have lost their new and visionary leader. They are in mourning. ","Sad..."));
            GameManager.playerKingdom.removeKingdomLife(10);
            GameManager.playerKingdom.removeMilitaryPower(10);
            
            return false;
        }));

        getChoices.Add(new Choice(20,0,0,"Invite him to a great diner and poison his food. ",()=> {
            GameManager.AddEventForToday(new Message("Invite him to a great diner and poison his food. ","People have lost their new and visionary leader. They are in mourning and suspect you to have killed him. ","As always..."));
            GameManager.playerKingdom.removeKingdomLife(50);
            return false;
            
        }));
        getChoices.Add(new Choice(0,0,0,"Agree with him, stop monarchy, and set a new political system called... let's say.. democracy? ",()=> {
            GameManager.AddEventForToday(new Message("Agree with him","You decided to leave your throne. It's the end of a great journey, but the beginning of another beautiful one. You quit with a good amount of money, and buy a little house in the countryside. You live in peace with your wife and children for the rest of your life. ","Short live the King"));
            GameManager.playerKingdom.removeKingdomLife(100);
            return false;
            
        }));
        
    }
}
