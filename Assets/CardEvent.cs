using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEvent 
{
    private List<Choice> choices;
    private int daysToPlay;
    private int weight;

    public int Weight { get => weight; set => weight = value; }


    public CardEvent()
    {
        daysToPlay = -10;
        Weight = 1;
    }


    public void choose(int choix)
    {
        choices[choix].process();
    }

    public void drawEvent()
    {
        //draw :) 
    }
}
