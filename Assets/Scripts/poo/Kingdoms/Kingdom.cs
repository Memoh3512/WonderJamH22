using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingdom
{
    public List<Unit> Units { get => units; set => units = value; }
    private string name;   
    
    private List<Unit> units; //toutes les units

    private int gold = 0;
    private int militaryPower = 100;
    private int kingdomLife = 100;

    private int greediness;
    private int growth; //50 = moyen
    private float variance; //TODO
    
    public int Gold => gold;
    public int MilitaryPower => militaryPower;
    public int KingdomLife => kingdomLife;
    

    public string Name { get => name; set => name = value; }

    public void removeGold(int toRemove)
    {
        gold -= toRemove;
    }
    public void removeKingdomLife(int toRemove)
    {
        kingdomLife -= toRemove;
    }
    public void removeMilitaryPower(int toRemove)
    {
        militaryPower -= toRemove;
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
