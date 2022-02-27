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
        getChoices.Add(new Choice(-50, 0, 0, "The yellow seed", () => {
            GameManager.addPlannedEvent( new Trees1() );
            return false;
        }));
       
        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(-50, 0, 0, "The blue seed", () => {
            GameManager.addPlannedEvent( new Trees2() );
            return false;
        }));
        
        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(-50, 0, 0, "The green seed", () => {
            GameManager.addPlannedEvent( new Trees3() );
            return false;
        }));
        //TODO % de chance que l'arbre pousse pas
    }
}