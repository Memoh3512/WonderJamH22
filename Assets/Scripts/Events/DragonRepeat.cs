using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRepeat : CardEvent
{
    public DragonRepeat(Unit dragon) {
        DaysToPlay = 2;
        Name = "Dragon";
        Description = "Your dragon keeps getting bigger and stronger. However it also eats more and more food.";

        if (GameManager.playerKingdom.Units.Contains(dragon))
        {
            getChoices.Add(new Choice(dragon.Hp, 0, -2, "Keep feeding it", () =>
            {
                dragon.Hp += 20;
                dragon.Damage += 10;
                dragon.MpValue += 2;
                GameManager.addPlannedEvent(new DragonRepeat(dragon));
                return false;
            }));


            getChoices.Add(new Choice(0, 30, dragon.MpValue, "Don't feed your dragon", () =>
            {
                GameManager.AddEventForToday(new Message("Destruction", "Your unfed dragon went crazy, destroying everything in its path before being killed by our army.", "..."));
                GameManager.playerKingdom.Units.Remove(dragon);
                return false;
            }));
        }
        else
        {

            Description = "The population is mourning the recent death of the kingdom's dragon.";
            getChoices.Add(new Choice(0, 5, 0, ":'(", () => { return false; }));
        }


    }
}
