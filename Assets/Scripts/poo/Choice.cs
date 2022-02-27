using System;
using System.Collections.Generic;
using UnityEngine;

public class Choice
{
    
    private int mMoney;
    private int mKingLife;
    private int mMilitaryPower;
    private string description;

    public int MMoney { get => mMoney; set => mMoney = value; }
    public int MKingLife { get => mKingLife; set => mKingLife = value; }
    public int MMilitaryPower { get => mMilitaryPower; set => mMilitaryPower = value; }
    
    public string Description { get => description; set => description = value; }

    public delegate bool ChooseEventHandler();

    public event ChooseEventHandler onChoose;

    public Choice(int moneyCost, int lifeCost, int militaryCost,string description, ChooseEventHandler onChoose )
    {
        this.description = description;
        MMoney = moneyCost;
        MKingLife = lifeCost;
        MMilitaryPower = militaryCost;

        this.onChoose = onChoose;
    }

    public void process()
    {
        
        bool war = onChoose.Invoke();
        if (!war) GameManager.playNextEvent();
        else
        {
            SoundPlayer.instance.SetMusic(Songs.War, 1f, TransitionBehavior.Continue);
            LevelLoader.instance.LoadScene("Combat", TransitionTypes.Fight);
        }
        
        GameManager.playerKingdom.removeGold(mMoney);
        GameManager.playerKingdom.removeKingdomLife(mKingLife);
        GameManager.playerKingdom.removeMilitaryPower(mMilitaryPower);
        
        GameObject.FindObjectOfType<GameUI>().UpdateUIValues();

    }

}
