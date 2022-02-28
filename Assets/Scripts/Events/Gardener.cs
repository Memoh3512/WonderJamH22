using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardener : CardEvent
{
    public Gardener()
    {
        
        Name = "Gardener";
        Description = "Hi! I'm a gardener and I would like to open a public garden. Can you lend me some money? ";

        getChoices.Add(new Choice(20,0,0,"Yes",()=> {
            GameManager.AddEventForToday(new Message("Gardening is fun!","The garden is beautiful, people are happy, and some neighbors come to see this. It costs a little bit, but you made even more because people pay to see it.","Nice", () =>
            {
                GameManager.playerKingdom.removeGold(-50);
                return false;
            }));
            return false;
        }));

        getChoices.Add(new Choice(0,15,0,"No",()=> {
            GameManager.AddEventForToday(new Message("No flowers","The gardener is so mad that he'll make poisonous plants grow everywhere in the village.","Noooooooo"));
            return false;
        }));
    }
}
