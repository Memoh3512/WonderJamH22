using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSeries3 : CardEvent
{
   public AlienSeries3()
    {
        DaysToPlay = 2;
        Name = "Crashed Disc";
        Description = "While investigating the mysterious sightings our soldiers have found one of those " +
            "flying metalic discs crashed in the middle of the forest. After searching thoroughly " +
            "the inside of the giant disc they found a weird unconscious organism and a pile of powerful weapons.";

        getChoices.Add(new Choice(0, 0, -200, "Kill the organism and steal the weapons!", () =>
        {
            GameManager.AddEventForToday(new Message("Alien Invasion", "After killing the poor organism and stealing it's weapons, a message was sent " +
                "from the flying saucer to a distant civilization. Within a few short hours the an entire alien population landed on earth to wage the " + GameManager.playerKingdom.Name + " kingdom war", "Uh oh..."));
            GameManager.aiKingdoms.Add(new KingdomAlien());
            GameObject.FindObjectOfType<KingdomsUISpawner>().RefreshKingdomsUI();
            return false;
        }));

        getChoices.Add(new Choice(0, 10, -60, "We really shouldn't get involved, call back the soldiers", () => {
            return false;
        }));
    }
}
