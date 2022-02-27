using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadAttack : CardEvent
{
   public MadAttack(Kingdom k)
   {
        Name = "The " + k.Name + " Kingdom has gone too far";
        Description = "Our people are unhappy with the " + k.Name + " Kingdom and they are asking for blood! ";
        getChoices.Add(new Choice(0, 0, 0, "ALATAK!", () =>
        {
            GameManager.fightOpponent = k;
            return true;
        }));

        getChoices.Add(new Choice(0, 10, 0, "Don't fight.", () =>
        {
            return false;
        }));
   }
}
