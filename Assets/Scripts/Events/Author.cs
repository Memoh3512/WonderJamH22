using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Author: CardEvent
{
    public Author()
    {
        
        Name = "Investing in knowledge";
        Description = "An author would like to write a book, but he does not know what type. He is asking for your advice. " +
                      "What subject would you like the book to be about?";

        
        //Choix + cout
        getChoices.Add(new Choice(0, 0, -20, "War", () => {
            return false;
        }));
        
        //Choix + cout + carte plus tard ( la carte est un autre object )
        getChoices.Add(new Choice(0, 0, 0, "Economy", () => {
            GameManager.addPlannedEvent( new Author2() );
            return false;
        }));

        getChoices.Add(new Choice(0,10,0,"Philosophy",()=> {
            GameManager.AddEventForToday(new Message("Philosophy book","These writings about ways of thinking were not appreciated by the public. " +
                                                                       "Way too abstract and complicated for the peasants, the book was a pure failure.","At least they know that they know nothing..."));
            return false;
        }));
        
        //Choix + cout
        getChoices.Add(new Choice(0, -5, 0, "For children", () => {
            return false;
        }));
        
        
    }
}