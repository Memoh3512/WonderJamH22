using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryOffers: CardEvent
{
    public MilitaryOffers()
    {
        
        //TODO remettre dans le deck
        Name = "Best deals are here!";
        Description = "We received a special offer from the market place, which needs to flow out their old stock." +
                      "They ask you if you want to buy weapons and armor for our soldiers.";

       
        //Choix + cout
        getChoices.Add(new Choice(30, 0, -50, "50 weapons for 30$", () => {
            return false;
        }));

        //Choix + cout
        getChoices.Add(new Choice(70, 0, -100, "100 weapons for 70$", () => {
            return false;
        }));
        //Choix + cout
        getChoices.Add(new Choice(100, 0, -200, "200 weapons for 100$ ", () => {
            return false;
        }));
        //Choix + cout
        getChoices.Add(new Choice(25, 0, 0, "Not buy anything.", () => {
            return false;
        }));
    }
}