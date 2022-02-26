using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beluga : CardEvent
{
    public Beluga()
    {
        DaysToPlay = 5;
        Name = "BELUGA!";
        Description = "The kingdom beluga dove into the sea. A few moments later it brought back a another huge treasure chest!";
        getChoices.Add(new Choice(0, 0, 0, "Yay!", () => {
            GameManager.playerKingdom.removeGold(-100);
            GameManager.addPlannedEvent(new Beluga());
            return false;
        }));
    }
  
}
