using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCounselor : CardEvent
{
   private Kingdom kingdomToFight;
   public WarCounselor(int weight,int daysToPlay)
    {
        Name = "War Counselor";
        //kingdomToFight = GameManager.aiKingdoms[0];
        //kingdomToFight = new Kingdom();
        //kingdomToFight.Name = "CUNGFU";
        this.Weight = weight;
        
    }


    public override void drawEvent()
    {
        int random = Random.Range(0, 101);
        if(random >= 70)
        {
            kingdomToFight = GameManager.aiKingdoms[0];
            foreach(Kingdom k in GameManager.aiKingdoms)
            {
                if(k.MilitaryPower < kingdomToFight.MilitaryPower)
                {
                    kingdomToFight = k;
                }
            }
        }
        else
        {
            foreach (Kingdom k in GameManager.aiKingdoms)
            {
                if (k.MilitaryPower > kingdomToFight.MilitaryPower)
                {
                    kingdomToFight = k;
                }
            }
        }

        this.Description = "You have received a message from your army commander : \n" +
            "\"Your excellency, " + kingdomToFight.Name + " Kingdom has shown signs of weakness. I believe we should take this opportunity to attack them while they're at a low point!\"\n" +
            "(While the commander's intel is usually right, mistakes always happen.)";

        Choice choice1 = new Choice(0, 0, 0, "ALATAK!", () => {
            GameManager.fightOpponent = kingdomToFight;
            
            //STARTO FIGHTO
            return true;
        });
        getChoices.Add(choice1);
        getChoices.Add(new Choice(0, 0, 0, "Abstain from attacking", () =>
        {
            
            GameManager.AddEventForToday(new Message("Test", "WOWOW", "OKAY!! :)"));
            return false;
        }));
        base.drawEvent();
    }
}
