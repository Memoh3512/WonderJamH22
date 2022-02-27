using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingdom
{
    private Unit baseUnit;
    public List<Unit> Units { get => units; set => units = value; }
    private string name;
    private bool isPlayer = false;
    
    private List<Unit> units; //toutes les units

    private int gold = 50;
    private int militaryPower = 100;
    private int kingdomLife = 100;

    protected int greediness; // Largeur de la bande
    protected int growth; //50 = moyen + meilleur rendement
    protected float variance; //1.7-2.5
    
    public int Gold => gold;
    public int MilitaryPower => militaryPower;
    public int KingdomLife => kingdomLife;
    public Kingdom(bool isPlayer = false)
    {
        this.isPlayer = isPlayer;
        if (isPlayer)
        {
            BaseUnit = new Unit(Resources.Load<Sprite>("Units/cowboy"),10,5,1);
        }
    }
    public string Name { get => name; set => name = value; }
    public Unit BaseUnit { get => baseUnit; set => baseUnit = value; }

    public void removeGold(int toRemove)
    {
        gold -= toRemove;
        if (isPlayer && toRemove != 0)
        {
            NotificationManager.startNotification(0,-toRemove);
        }
    }
    public void removeKingdomLife(int toRemove)
    {
        kingdomLife -= toRemove;
        if (isPlayer && toRemove != 0)
        {
            NotificationManager.startNotification(1,-toRemove);
            if (kingdomLife <= 0)
            {
                GameManager.deathNote = "The people have taken you by assault!";
                LevelLoader.instance.LoadScene("LoseScene", TransitionTypes.CrossFade);
            }
        }
    }
    public void removeMilitaryPower(int toRemove)
    {
        militaryPower -= toRemove;
        if (isPlayer && toRemove != 0)
        {
            NotificationManager.startNotification(2,-toRemove);
            if (militaryPower <= 0)
            {
                GameManager.deathNote = "Your army was ran dry.";
                LevelLoader.instance.LoadScene("LoseScene", TransitionTypes.CrossFade);
            }
        }
    }
    public bool canBuy(int wantToBuyPrice)
    {
        if (gold >= wantToBuyPrice)
            return true;
        else
            return false;
    }
    public bool canMilitaryPower(int wantMilitaryPower)
    {
        if (militaryPower >= wantMilitaryPower)
            return true;
        else
            return false;
    }
    public bool canKingdomlife(int wantKingdomlife)
    {
        if (kingdomLife >= wantKingdomlife)
            return true;
        else
            return false;
    }

    public void next()
    {
        int toAdd = greediness;
        float random = Random.Range(1, Mathf.Pow(10, variance));

        int checkSign = (int)Mathf.Sign(Random.Range(-100 + growth, growth + 1));

        if (checkSign > 0) {
            toAdd = (int)((variance - Mathf.Log10(random)) / variance * greediness)* growth/100;
        }else
        {
            toAdd = (int)((variance - Mathf.Log10(random)) / variance * - greediness)* 1 - (growth/100);
        }
        militaryPower = militaryPower + toAdd;
    }
}
