using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : CardEvent
{
  public Drug()
  {
        Name = "Experimental Drug";
        Description = "Our kingdom's researchers have come up with a new experimental drug to make super soldiers, but its side effects are unknown.";
        getChoices.Add(new Choice(0, 0, 5, "Try the drug on a few soldiers", () => {
            int success = 0;
            for(int i  = 0; i < 5; i++)
            {
                if(Random.Range(1,101) <= 10)
                {
                    success++;
                }
            }
            string text = "";
            string button = "";
            if (success == 0) {
                text = "None of them survived.";
                button = ":(";
            }
            else {
                text = "" + success + " of them survived, giving birth to " + success + " super soldiers!";
                button = ">:)";
            }



            GameManager.AddEventForToday(new Message("Experimental Drug - Follow up", "After giving the drugs to the soldiers," + text, button, () =>
            {
                if (success > 0) {
                    GameManager.playerKingdom.removeMilitaryPower(-success * 5);
                    for (int i = 0; i < success; i++)
                        GameManager.playerKingdom.Units.Add(new Unit(GameManager.playerKingdom.BaseUnit.Sprite, 30, 15, 3));
                }
                GameManager.addEvent(new Drug());
                return false;
                
            }));
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Drugs are bad",() => { GameManager.addEvent(new Drug()); return false; }));
  }
}
