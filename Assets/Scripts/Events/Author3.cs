using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Author3 : CardEvent
{
    public Author3()
    {

        DaysToPlay = 5;
        Name = "Stonks";
        Description = "It seems that the book's advice was really useful. " +
        "You've tripled your investment! ";
        

        //Choix + cout
        getChoices.Add(new Choice(-75, 0, 0, "I'm so good at this", () => {
            return false;
        }));

    }
}
