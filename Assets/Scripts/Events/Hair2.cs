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
        
        getChoices.Add(new Choice(0,5,0,"Tell the hairdresser herself to take care of these. ",()=> {
            GameManager.AddEventForToday(new Message("Hairdresser vs hair monster. ", "The hairdresser stopped her salon and now have to cut hair for the rest of her life. ","Too bad"));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Ask the magician to do something",()=> {
            GameManager.AddEventForToday(new Message("Magician vs hair monster","The magician transforms the hairs into spaghetti. The man opened an Italian restaurant and became famous. Even among others Kingdoms. ","So imaginative"));
           GameManager.playerKingdom.removeKingdomLife(-15);
           Kingdom kd = GameManager.aiKingdoms[Random.Range(0, GameManager.aiKingdoms.Count)];
           kd.IncrementRelation();
            return false;
        }));
        getChoices.Add(new Choice(-200,0,0,"Use the hairs to make an industry and exploit them. ",()=> {
            GameManager.AddEventForToday(new Message("Hair Kingdom. ","The hairs became all sorts of things: paint brushes, carpets, and even blankets. But one morning, the long-haired man has disappeared... we suspect the Furries have stolen him for his \"fur\"....","ALATAK!",() => {

                foreach (Kingdom k in GameManager.aiKingdoms)
                {
                    if(k.Name == "Furry")
                    {
                        GameManager.fightOpponent = k;
                        return true;
                    }
                }
                return false;

            }));

            return false;
        }));
       
            
    }
}
