using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Author2 : CardEvent
{
    public Author2()
    {

        DaysToPlay = 2;
        Name = "Investment? Lets try it";
        Description = "The book about economy was a real success! " +
                      "Attracted by the concept of making money, people who read the book learned to invest! " +
                      "You could try it too!";
        

        //Choix + cout
        getChoices.Add(new Choice(-100, 0, 0, "Try to invest!", () => {
            return false;
        }));

    }
}