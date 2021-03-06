using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingdom
{
    private Unit baseUnit;
    public List<Unit> Units { get => units; set => units = value; }
    private string name;
    private bool isPlayer = false;
    
    private List<Unit> units = new List<Unit>(); //toutes les units

    private int gold = 50;
    private int militaryPower = 100;
    private int kingdomLife = 100;

    protected int greediness; // Largeur de la bande
    protected int growth; //50 = moyen + meilleur rendement
    protected float variance; //1.7-2.5

    public Sprite icon;
    private int relation = 0;
    
    public int Gold => gold;
    public int MilitaryPower => militaryPower;
    public int KingdomLife => kingdomLife;

    public static int costFlood = 100;
    
    public Kingdom(bool isPlayer = false)
    {

        icon = Resources.Load<Sprite>("Icon/Icon-Human");
        if (isPlayer)
        {
            BaseUnit = new Unit(Resources.Load<Sprite>("Units/chevalier"),10,5,1);
        }

    }
    public Kingdom(Sprite icon, bool isPlayer = false)
    {

        this.isPlayer = isPlayer;
        if (isPlayer)
        {
            BaseUnit = new Unit(Resources.Load<Sprite>("Units/chevalier"),10,5,1);
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
        else
        {

            if (!isPlayer)
            {

                KingdomsUISpawner s = Object.FindObjectOfType<KingdomsUISpawner>();
                int i = 0;
                foreach (Kingdom k in GameManager.aiKingdoms)
                {

                    if (k.name == name) break;
                    i++;

                }
                s?.StatChange(i, Stat.Gold, toRemove < 0);

            }
            
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
        else
        {

            if (!isPlayer)
            {

                KingdomsUISpawner s = Object.FindObjectOfType<KingdomsUISpawner>();
                int i = 0;
                foreach (Kingdom k in GameManager.aiKingdoms)
                {

                    if (k.name == name) break;
                    i++;

                }
                s?.StatChange(i, Stat.KingHealth, toRemove < 0);

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
                GameManager.deathNote = "Your army has run dry.";
                LevelLoader.instance.LoadScene("LoseScene", TransitionTypes.CrossFade);
            }
        }       
        else
        {

            if (!isPlayer)
            {

                KingdomsUISpawner s = Object.FindObjectOfType<KingdomsUISpawner>();
                int i = 0;
                if (GameManager.aiKingdoms != null)
                {
                    
                    foreach (Kingdom k in GameManager.aiKingdoms)
                    {

                        if (k.name == name) break;
                        i++;

                    }   
                    
                }
                s?.StatChange(i, Stat.MilitaryPower, toRemove < 0);

            }
            
        }
    }

    public void IncrementRelation()
    {

        relation++;
        Mathf.Min(1, relation);

    }

    public void DecrementRelation()
    {
        
        relation--;
        relation = Mathf.Max(-1, relation);
    }

    public int Relation => relation;
    
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
        //Growth des villages
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

        //display
        KingdomsUISpawner s = Object.FindObjectOfType<KingdomsUISpawner>();
        int i = 0;
        foreach (Kingdom k in GameManager.aiKingdoms)
        {

            if (k.name == name) break;
            i++;

        }
        s?.StatChange(i, Stat.MilitaryPower, toAdd >= 0);

        //Pars en fight is on peut
        if (militaryPower > 0)
        {
            // Fighting card chance
            float fightOdd = 0.15f;
            switch (relation)
            {
                case 1: fightOdd = 0.05f;
                    break;
                case -1 : fightOdd = 0.35f;
                    break;
            }

            if (Random.Range(0f, 1f) <= fightOdd)
            {
                GameManager.AddEventForToday(new IncomingAttack(this));
            }
        }
        else
        {
            //Remove le kingdom
            GameManager.aiKingdoms.Remove(this);
            Object.FindObjectOfType<GameUI>().UpdateUIValues();
            GameManager.AddEventForToday(new Message("Fallen kingdom","The kingdom "+this.name+" has fallen, bad decisions were made.","Good for me"));
        }

    }
}
