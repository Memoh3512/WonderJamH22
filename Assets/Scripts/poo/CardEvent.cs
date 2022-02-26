using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent 
{
    private List<Choice> choices;
    private int daysToPlay;
    private int weight;
    
    public int DaysToPlay { get => daysToPlay; private set => daysToPlay=value; }
    public int Weight { get => weight; set => weight = value; }


    public CardEvent()
    {
        daysToPlay = -10;
        Weight = 1;
    }


    public void choose(int choix)
    {
        Choice choiceChosen = choices[choix];
        if(GameManager.playerKingdom.canBuy(choiceChosen.MMoney) && GameManager.playerKingdom.canMilitaryPower(choiceChosen.MMilitaryPower) && GameManager.playerKingdom.canKingdomlife(choiceChosen.MKingLife))
        {
            choiceChosen.process();
        }
    }
    public void removeDays(int days)
    {
        daysToPlay -= days;
    }
    public void drawEvent()
    {
        //draw :) 
    }
}
