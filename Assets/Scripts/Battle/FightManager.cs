using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class FightManager : MonoBehaviour
{
    [SerializeField]
    public GameObject enSpawner;
    public GameObject allySpawner;
    public GameObject baseFighterPrefab;
    private List<GameObject> allEnemies;
    private List<GameObject> allAllies;
    public static List<Unit> woundedAllies;
    public static List<Unit> woundedEnemies;
    public static List<Unit> fullDeadAllies;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        allEnemies = new List<GameObject>();
        allAllies = new List<GameObject>();

        woundedAllies = new List<Unit>(){};
        woundedEnemies = new List<Unit>(){};
        fullDeadAllies = new List<Unit>(){};
       

        //DEBUG this
        //TODO remove icitte quand on a les kingdoms
        if (GameManager.firstPlay)
        {
            GameManager.fightOpponent = new KingdomCowboy();
            GameManager.playerKingdom = new Kingdom(true);
            GameManager.playerKingdom.Units = new List<Unit>() { };
            GameManager.fightOpponent.Units = new List<Unit>() { };
        }

        GameUI.valuesBeforeFight=new int[]{GameManager.playerKingdom.Gold,GameManager.playerKingdom.MilitaryPower,GameManager.playerKingdom.KingdomLife};

        //Enemy
        spawnFighters(GameManager.fightOpponent,enSpawner,allEnemies,1,true);

        //Allies
        spawnFighters(GameManager.playerKingdom,allySpawner,allAllies,0);
    }
    private void Start()
    {
        StartFight();
    }
    void spawnFighters(Kingdom kingdom, GameObject spawner,List<GameObject> allSpawned,int team,bool flipSprite = false)
    {
        //Random pos
        Vector3 spawnerPos=spawner.GetComponent<Transform>().position;
        float rectWidth = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.x*spawner.GetComponent<Transform>().localScale.x;
        float rectHeight = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.y*spawner.GetComponent<Transform>().localScale.y;


        bool playerSpawned = false;
        int currSpecialUnit = 0;
        for (int i = 0; i < kingdom.MilitaryPower; i++)
        {
            Unit toInstantiate=kingdom.BaseUnit;//Base unit
            //Si on peut prendre une grosse unit on prend
            if (kingdom.Units.Count>currSpecialUnit&&kingdom.Units[currSpecialUnit].MpValue <= kingdom.MilitaryPower - i)
            {
                i += GameManager.playerKingdom.Units[currSpecialUnit].MpValue;
                toInstantiate = GameManager.playerKingdom.Units[currSpecialUnit];
                currSpecialUnit++;
            }


            
            //Set les values du fighter dapres unit
            GameObject currFighter = Instantiate(baseFighterPrefab);
            currFighter.GetComponent<Fighter>().Damage = toInstantiate.Damage;
            currFighter.GetComponent<Fighter>().Life = toInstantiate.Hp;
            currFighter.GetComponent<Fighter>().Team = team;
            currFighter.GetComponent<Transform>().localScale = Vector3.one * toInstantiate.Scale;
            currFighter.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = toInstantiate.Sprite;
            
            if (!playerSpawned && team == 0)
            {

                currFighter.GetComponent<Fighter>().player = true;
                currFighter.transform.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
                playerSpawned = true;

            }
            
            //Set randPos
            float xPos = spawnerPos.x + Random.Range(-rectWidth, rectWidth);
            float yPos = spawnerPos.z + Random.Range(-rectHeight, rectHeight);
            currFighter.transform.position = new Vector3(xPos, spawnerPos.y+2.25f, yPos);
            
            //Flip le sprite si besoin
            if (flipSprite)
            {
                currFighter.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !currFighter.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX;
            }
            //Add a liste de spawned
            allSpawned.Add(currFighter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // CHECKS LOSE/WIN
        string whoWon = "No one";
        bool done = false;
        if (allAllies.Count <= 0)
        {
            done = true;
            whoWon = "Enemies";
        }
        else if(allEnemies.Count <= 0)
        {
            whoWon = "Allies";
            done = true;
        }
        if (done)
        {
            Debug.Log("Fight is done : "+whoWon + " Won");
            
            int powerBefore = GameManager.playerKingdom.MilitaryPower;
            int losePower = 0;
            foreach (var deadUnit in woundedAllies.ToList())
            {
                if(Random.Range(0, 4)==1)
                {
                    fullDeadAllies.Add(deadUnit);
                    woundedAllies.Remove(deadUnit);
                    losePower += deadUnit.MpValue;
                    GameManager.playerKingdom.Units.Remove(deadUnit);
                }
            }
            Debug.Log("Allies Lose "+losePower+" military power from fight");
            
            int losePowerEn = 0;
            foreach (var deadUnit in woundedEnemies.ToList())
            {
                if(Random.Range(0, 4)==1)
                {
                    GameManager.fightOpponent.removeMilitaryPower(deadUnit.MpValue);
                    losePowerEn += deadUnit.MpValue;
                }
            }
            Debug.Log("Ennemies Lose "+losePowerEn+" military power from fight");
            GameManager.playerKingdom.removeMilitaryPower(losePowerEn);
            
            GameManager.playerKingdom.DecrementRelation();
            int goldGained = 0;
            if (whoWon != "Allies")
            {
                GameManager.playerKingdom.removeKingdomLife(15);
            }
            else
            {
                goldGained = woundedEnemies.Count;
                GameManager.playerKingdom.removeGold(goldGained);
            }
            
            //Affichage
            FindObjectOfType<FightRecapUI>().OpenMenu(whoWon,losePower,losePowerEn,goldGained);
            Destroy(gameObject);
        }
        
    }
    void StartFight()
    {
        foreach (var fighter in allEnemies)
        {
            fighter.GetComponent<Fighter>().myAllies = allEnemies;
            fighter.GetComponent<Fighter>().myEnemies = allAllies;
            fighter.GetComponent<Fighter>().getClosestTarget();
        }
        foreach (var fighter in allAllies)
        {
            fighter.GetComponent<Fighter>().myAllies = allAllies;
            fighter.GetComponent<Fighter>().myEnemies = allEnemies;
            fighter.GetComponent<Fighter>().getClosestTarget();
        }
    }
}
