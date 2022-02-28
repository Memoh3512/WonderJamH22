using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserters : CardEvent
{
    public Deserters()
    {
        Name = "Deserters";
    }



    public override void drawEvent()
    {
        Kingdom kd = GameManager.aiKingdoms[Random.Range(0, GameManager.aiKingdoms.Count)];
        Description = "Deserters from the " + kd.Name + " kingdom have come to our kingdom after escaping their army";
        getChoices.Add(new Choice(0, 0, -5, "Capture them and use them as soldiers", () =>
        {
            for(int i = 0; i < 5; i++)
            {
                GameManager.playerKingdom.Units.Add(new Unit(kd.BaseUnit));
            }
            //GameManager.addEvent(new Deserters());
            return false;
        }));

        getChoices.Add(new Choice(0, 0, 0, "Lock them up.", () =>
        {
            if (Random.Range(1, 101) < 40)
            {
                GameManager.addPlannedEvent(new Message("Tactical Geniuses", "The deserters previously thrown in prison, " +
                    "through countless games of battleship, became tactical experts and volounteered help in the army. We are now able to command more soldiers into battle", "Awesome!", () =>
                    {
                        GameManager.playerKingdom.removeMilitaryPower(-10);
                        return false;
                    }, 2));
            }
            return false;
        }));

        getChoices.Add(new Choice(0, 0, 0, "Let them be",() => { return false; }));
        GameManager.addEvent(new Deserters());
        base.drawEvent();
    }
}