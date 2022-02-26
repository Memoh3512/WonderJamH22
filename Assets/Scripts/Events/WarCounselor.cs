using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCounselor : CardEvent
{
   public WarCounselor(int weight,int daysToPlay)
    {
        this.Weight = weight;
        Choice choice1 = new Choice(0,0,0,new List<CardEvent>(),() => {
        
        });
    }
}
