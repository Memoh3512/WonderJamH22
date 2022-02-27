using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair2 : CardEvent
{
    public Hair2()
    {
        
        Name = "New client for the hairdresser";
        Description = "A bald customer entered the salon and asked if the woman could do anything for him. She made him a potion from peanut butter to apply. Now, he hair won't stop growing, covering half the city in hair. What should we do?";

        DaysToPlay = 2;
        
        getChoices.Add(new Choice(0,0,0,"Tell the hairdresser herself to take care of these. ",()=> {
            GameManager.AddEventForToday(new Message("Tell the hairdresser herself to take care of these. ","The hairdresser stopped her salon and now have to cut hair for the rest of her life. ","Too bad"));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Ask the magician to do something",()=> {
            GameManager.AddEventForToday(new Message("Ask the magician to do something","The magician transforms the hairs into spaghettis. The man opened an Italian restaurant that became famous. Even among others villages. ","So imaginative"));
           GameManager.playerKingdom.removeKingdomLife(-15);
           Kingdom kd = GameManager.aiKingdoms[Random.Range(0, GameManager.aiKingdoms.Count)];
           kd.IncrementRelation();
            return false;
        }));
        getChoices.Add(new Choice(0,0,0,"Using the hairs to make an industry and exploit them. ",()=> {
            GameManager.AddEventForToday(new Message("Using the hairs to make an industry and exploit them. ","The hairs became all sorts of things: paint brushes, carpets, and even blankets. But one morning, the long-haired man has disappeared... we suspect the Furries to have stolen him for his \"fur\"....","Oh no"));
            return false;
        }));
       
            
    }
}
