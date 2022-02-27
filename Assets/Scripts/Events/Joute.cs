using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joute: CardEvent
{
    public Joute()
    {
        
        Name = "Joust";
        Description = "To determine which one is the best, the knights decided to set up a joust. They will be facing each other, trying to push their opponent off their horse. According to you, for 30 bucks, who is going to win? If you guess right, you double your cash.";

        getChoices.Add(new Choice(0,0,0,"Arthur",()=> {
           
            return false;
        }));

        getChoices.Add(new Choice(0,0,0,"Lancelot",()=> {
            
            return false;
        }));
        getChoices.Add(new Choice(0,0,0,"Bob",()=> {
            
            return false;
        }));
        getChoices.Add(new Choice(0,0,0,"Percival",()=> {
            
            return false;
        }));
    }
}
