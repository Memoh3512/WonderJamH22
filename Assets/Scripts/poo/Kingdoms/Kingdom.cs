using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingdom
{
    public static List<GameObject> Units => units;
   
    
    private static List<GameObject> units; //toutes les units

    private int gold = 0;
    private int militaryPower = 100;
    private int kingdomLife = 100;
    
    public int Gold => gold;
    public int MilitaryPower => militaryPower;
    public int KingdomLife => kingdomLife;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
