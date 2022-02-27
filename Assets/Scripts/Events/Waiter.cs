using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : CardEvent
{
   public Waiter()
    {
        Name = "Fire in the city!";
        Description = "Alert ! A huge fire broke out in the kingdom's fanciest restaurant. Even worst, the head chef Garden Brightday " +
            "and the head waiter Fest Cerving are stuck on opposite sides of the building, making it only possible to save one of them.";
        getChoices.Add(new Choice(0, -10, 0, "Save Garden Brightday", () =>
        {
            return false;
        }));
        getChoices.Add(new Choice(0, 0, -10, "Save Fest Cerving", () =>
        {
          //  GameManager.playerKingdom.Units.Add(new Unit()); meilleur qu'un soldat normal. sprite de serveur si possible.
            GameManager.AddEventForToday(new Message("Savior","After saving Fest Cerving, he decided to quit being waiter and pursue " +
                "a safer career, joining the army","Great!"));
            GameManager.playerKingdom.Units.Add(new Unit(Resources.Load<Sprite>("Units/maid"), 75, 20, 1f, 10));
            return false;
        }));
    }
}