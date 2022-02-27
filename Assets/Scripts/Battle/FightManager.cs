using System;
using System.Collections;
using System.Collections.Generic;
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
    public static int soldiersDead;
    public static int enemiesDead;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        allEnemies = new List<GameObject>();
        allAllies = new List<GameObject>();

        soldiersDead = 0;
        enemiesDead = 0;
        
        //DEBUG this
        //TODO remove icitte quand on a les kingdoms
        GameManager.fightOpponent = new KingdomAlien();
        GameManager.playerKingdom = new Kingdom();
        GameManager.playerKingdom.Units = new List<Unit>(){};
        GameManager.fightOpponent.Units = new List<Unit>(){};
        for (int i = 0; i < 100; i++)
        {
            GameManager.playerKingdom.Units.Add(new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1));
            GameManager.fightOpponent.Units.Add(new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1));
        }
        
        
        
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
        Vector3 spawnerPos=spawner.GetComponent<Transform>().position;

        float rectWidth = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.x*spawner.GetComponent<Transform>().localScale.x;
        float rectHeight = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.y*spawner.GetComponent<Transform>().localScale.y;
        
        List<Unit> units = kingdom.Units;
        for (int i = 0; i < units.Count; i++)
        {
            Unit toInstantiate = units[i];
            
            float xPos = spawnerPos.x + Random.Range(-rectWidth, rectWidth);
            float yPos = spawnerPos.z + Random.Range(-rectHeight, rectHeight);
            
            GameObject currFighter = Instantiate(baseFighterPrefab);
            currFighter.GetComponent<Fighter>().Damage = toInstantiate.Damage;
            currFighter.GetComponent<Fighter>().Life = toInstantiate.Hp;
            currFighter.GetComponent<Fighter>().Team = team;
            currFighter.GetComponent<Transform>().localScale = Vector3.one * toInstantiate.Scale;
            currFighter.GetComponent<SpriteRenderer>().sprite = toInstantiate.Sprite;
            
            currFighter.transform.position = new Vector3(xPos, spawnerPos.y+2.25f, yPos);
            if (flipSprite)
            {
                currFighter.GetComponent<SpriteRenderer>().flipX = !currFighter.GetComponent<SpriteRenderer>().flipX;
            }
            allSpawned.Add(currFighter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string whoWon = "No one";
        bool done = false;
        if (allAllies.Count <= 0)
        {
            done = true;
            whoWon = "Enemies";
            //TODO win lose
        }
        else if(allEnemies.Count <= 0)
        {
            whoWon = "Allies";
            done = true;
        }
        if (done)
        {
            Debug.Log("Fight is done : "+whoWon + " Won");
            FindObjectOfType<FightRecapUI>().OpenMenu(whoWon);
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
