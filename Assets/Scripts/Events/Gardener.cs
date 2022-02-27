using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardener : CardEvent
{
    public Gardener()
    {
        
        Name = "Gardener";
        Description = "Hi! I'm a gardener and I would like to open a public garden. Can you lend me some money? ";

        getChoices.Add(new Choice(0,0,0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("Gardening is fun!","The garden is beautiful, people are happy, and some neighbors come to see this. It costs a little bit, but you make even more because people pay to see it.","Nice"));
            GameManager.playerKingdom.removeGold(-30);
            return false;
        }));

        getChoices.Add(new Choice(50,3,0,"No",()=> {
            GameManager.AddEventForToday(new Message("No","The gardener is so mad that he'll make poisonous plants grow everywhere in the village.","Noooooooo"));
            GameManager.playerKingdom.removeKingdomLife(15);
            return false;
        }));
        
    }
}
