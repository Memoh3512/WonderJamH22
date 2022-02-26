using System;
using System.Collections.Generic;

public class Choice
{

    private List<int> eventsToAdd;
    private int mMoney;
    private int mKingLife;
    private int mMilitaryPower;

    public delegate void ChooseEventHandler();

    public event ChooseEventHandler onChoose;

    public Choice(int moneyCost, int lifeCost, int militaryCost, List<int> eventsToAdd, ChooseEventHandler onChoose )
    {

        eventsToAdd = new List<int>(eventsToAdd);
        mMoney = moneyCost;
        mKingLife = lifeCost;
        mMilitaryPower = militaryCost;

        this.onChoose = onChoose;
    }

    public void process()
    {
        
        onChoose?.Invoke();
        
    }

}
