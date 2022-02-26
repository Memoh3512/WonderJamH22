using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes1 : CardEvent
{
    public Classes1()
    {
        
        Name = "Arts need to be learned?";
        Description = "Your village has an empty building that could be used to train people in art fields! What type of artist would you like to have?";

        getChoices.Add(new Choice(0,0,-20,"Tailors",()=> {
            GameManager.addPlannedEvent(new Message("Tailors","Tailors have made the troops better armor!","Armor, that's useful!"));
            return false;
        }));

        getChoices.Add(new Choice(50,3,0,"Painters",()=> {
            GameManager.addPlannedEvent(new Message("Painters","Painters are actually too deep into the subject of abstract art and have had a negative impact on your reign.","As always..."));
            return false;
        }));
        getChoices.Add(new Choice(-30,0,0,"Bakers",()=> {
            GameManager.addPlannedEvent(new Message("Bakers","They've made delicious pastries for your people. It made a couple of bucks!","Delicious"));
            return false;
        }));
        getChoices.Add(new Choice(10,-10,-10,"Musicians",()=> {
            GameManager.addPlannedEvent(new Message("Musicians","Musicians have brightened up the mood in the village! They've even brought some men from other villages!","As always..."));
            return false;//TODO donne des bonnes relations avec les autres
        }));
    }
}