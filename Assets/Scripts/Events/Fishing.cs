using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : CardEvent
{
   public Fishing()
   {
        Name = "Fishing with Pirates";
        Description = "The Pirates regularly organise formation days for fishermen. " +
            "They teach their knowledge to everyone who wish to perfect their fishing techniques. " +
            "But, Pirates being pirates, they could try to steal from us... Do you want to send a few of our fishermen? ";
       

        getChoices.Add(new Choice(0, 0, 0, "Not taking the risk.", () => { GameManager.addEvent(new Fishing()); return false; }));

   }


    public override void drawEvent()
    {
        if (GameManager.playerKingdom.Gold >= 50)
        {
            getChoices.Add(new Choice(0, 0, 0, "Send them", () => {
                int random = Random.Range(1, 101);
                if (random >= 90)
                {
                    GameManager.AddEventForToday(new Message("HUGE CATCH!", "Your fishermen caught an enormous red trout! The pirates are really " +
                        "proud of you!", "HUGE!", () => {
                            GameManager.playerKingdom.removeGold(-150);
                            foreach (Kingdom k in GameManager.aiKingdoms)
                            {
                                if (k.Name == "Pirates")
                                    k.IncrementRelation();
                            }
                            return false;
                        }));
                }
                else if (random >= 60)
                {
                    GameManager.AddEventForToday(new Message("Big Catch!", "Your fishermen caught a Salmon!", "Big!", () => {
                        GameManager.playerKingdom.removeGold(-50);
                        return false;
                    }));
                }
                else if (random >= 20)
                {
                    GameManager.AddEventForToday(new Message("Catch!", "Your fishermen caught a Sardine!", "wow", () => {
                        GameManager.playerKingdom.removeGold(-10);
                        return false;
                    }));
                }
                else
                {
                    GameManager.AddEventForToday(new Message("Stolen!", "Your fishermen caught an enormous golden tuna... but " +
                        "the pirates stole it! They also stole the fishing equipment!", "...", () => {
                            GameManager.playerKingdom.removeGold(50);
                            return false;
                        }));
                }
                GameManager.addEvent(new Fishing());
                return false;
            }));
        }
        base.drawEvent();
    }
}
