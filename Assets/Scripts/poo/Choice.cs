using System;
using System.Collections.Generic;

public class Choice
{

    private List<int> eventsToAdd;
    private int mMoney;
    private int mKingLife;
    private int mMilitaryPower;

    public int MMoney { get => mMoney; set => mMoney = value; }
    public int MKingLife { get => mKingLife; set => mKingLife = value; }
    public int MMilitaryPower { get => mMilitaryPower; set => mMilitaryPower = value; }

    public delegate void ChooseEventHandler();

    public event ChooseEventHandler onChoose;

    public Choice(int moneyCost, int lifeCost, int militaryCost, List<int> eventsToAdd, ChooseEventHandler onChoose )
    {

        eventsToAdd = new List<int>(eventsToAdd);
        MMoney = moneyCost;
        MKingLife = lifeCost;
        MMilitaryPower = militaryCost;

        this.onChoose = onChoose;
    }

    public void process()
    {
        
        onChoose?.Invoke();
        
    }

}
