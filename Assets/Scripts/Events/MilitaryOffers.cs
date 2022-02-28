using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryOffers: CardEvent
{
    public MilitaryOffers()
    {
        
        //TODO remettre dans le deck
        Name = "Best deals are here!";
        Description = "We received a special offer from the market place, which needs to flow out their old stock. " +
                      "They ask you if you want to buy weapons and armor for our soldiers.";
        
        //Choix + cout
        getChoices.Add(new Choice(30, 0, -50, "50 armors for 30$", () => {
            GameManager.addEvent(new MilitaryOffers());
            return false;
        }));

        //Choix + cout
        getChoices.Add(new Choice(70, 0, -100, "100 armors for 70$", () => {
            GameManager.addEvent(new MilitaryOffers());
            return false;
        }));
        //Choix + cout
        getChoices.Add(new Choice(150, 0, -200, "200 armors for 150$ ", () => {
            GameManager.addEvent(new MilitaryOffers());
            return false;
        }));
        //Choix + cout
        getChoices.Add(new Choice(0, 0, 0, "Don't buy anything.", () => {
            GameManager.addEvent(new MilitaryOffers());
            return false;
        }));
    }
}