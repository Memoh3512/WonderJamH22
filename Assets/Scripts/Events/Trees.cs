using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : CardEvent
{
    public Trees()
    {
        

        Name = "Glowing seeds";
        Description = "We found some weird glowing seeds in the forest. There are 3 of them. " +
                      "Which one should we try to plant?";
        

        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(0, 0, 0, "The yellow seed", () =>
        {
            GameManager.addCardIfRandom(75, new Trees1(), new Trees0());
            return false;
        }));
       
        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(0, 0, 0, "The blue seed", () =>
        {
            GameManager.addCardIfRandom(75,new Trees2(),new Trees0());
            return false;
        }));
        
        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(0, 0, 0, "The green seed", () => {
            GameManager.addCardIfRandom(75,new Trees3(),new Trees0());
            return false;
        }));
    }
}