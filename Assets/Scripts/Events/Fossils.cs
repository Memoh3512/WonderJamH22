using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossils : CardEvent
{
    public Fossils()
    {
        

        Name = "Inspiring history";
        Description = "Returning from a diplomatic talk with the Pirates at the beach, a soldier tripped on a big rock. " +
                      "Actually, it looks like an enormous bone. We should probably dig around in the sand. " +
                      "Where should we start?";

        //Choix + cout + apparait une autre carte
        getChoices.Add(new Choice(0, 0, -40, "East side", () => {
            GameManager.AddEventForToday(new Message("East side", "We found a lot of extremely little and pointy fish bones. " +
                                                                  "It inspired the botanist to craft poisonous darts that can be shot from a very far distance. ","And shoot them with a blowpipe!"));
            return false;
        }));

        //Choix + cout + apparait une autre carte
        getChoices.Add(new Choice(0, 0, -30, "West side", () => {
            GameManager.AddEventForToday(new Message("West side", "You found a fossil of a huge snake. " +
                                                                  "The scales inspired the blacksmith to forge better armor for the troops.", "Nice!"));
            return false;
        }));
        //Choix + cout + apparait une autre carte
        getChoices.Add(new Choice(0, 0, -10, "In the water", () => {
            GameManager.AddEventForToday(new Message("In the water", "We found a shell of an ancient tortoise. " +
                                                                     "It inspired the blacksmith to make better helmets for the troops. ", "Cool!"));
            return false;
        }));
       
    }
}