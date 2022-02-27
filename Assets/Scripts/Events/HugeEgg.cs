using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeEgg : CardEvent
{
    public HugeEgg()
    {
        Name = "Huge Egg!";
        Description = "A little girl from a small village found a huuuuge egg in a lake and, " +
            "with the help of the other villagers, brought it back in the kingdom";

        getChoices.Add(new Choice(0, -10, 0, "Cook it! Make a feast!", () =>
        {
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Let it hatch!",() => {
            CardEvent ce = new Message("BELUGA!", "The egg the little girl brought finally hatched revealing a glorious beluga! The recently hatched beluga immediately dove into the sea. A few moments later it brought back a huge treasure chest!","Yay!",
                () => {
                    GameManager.playerKingdom.removeGold(-100);
                    GameManager.addPlannedEvent(new Beluga());
            return false;
        });
            ce.DaysToPlay = 5;
            GameManager.addPlannedEvent(ce);
            return false;
        }));

        getChoices.Add(new Choice(0, 0, 0, "Try to sell it", () =>
        {
            CardEvent ce = new Message("Egg Waste", "After trying to sell the giant egg for several days and finally finding a buyer, the egg," +
                "too big to fit inside the buyer's house, exploded into a river of yolk and shells.","What a waste.");
            ce.DaysToPlay = 3;
            GameManager.addPlannedEvent(ce);
            return false;
        }));
            

    }
}
