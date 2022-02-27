using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : CardEvent
{
    public Flood()
    {
        Name = "Water everywhere!";
        Description = "A huge flood came and destroyed almost all of the houses and buildings. " +
                      "We need to reconstruct the village, otherwise we'll die. How do you want to deal with this?";

        //Choix + cout + apparait une autre carte
        getChoices.Add(new Choice(Kingdom.costFlood, 30, -0, "Host everyone in the castle", () => {
            GameManager.AddEventForToday(new Message("Host everybody", "You invited everybody to live ine the castle meanwhile they try to rebuild everything." +
                                                                       "But there is not enough room in the castle, so everyone is really squeezed.", "I did the best I could..."));
            return false;
        }));

        //Choix + cout
        getChoices.Add(new Choice(0, 50, 0, "Make the villagers rebuild everything themselves.", () => {
            return false;
        }));

    }
}