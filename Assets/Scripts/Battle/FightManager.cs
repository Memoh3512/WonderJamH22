using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField]
    public GameObject enSpawner;
    public GameObject allySpawner;
    public GameObject baseFighterPrefab;
    private List<GameObject> allEnemies;
    private List<GameObject> allAllies;
    
    // Start is called before the first frame update
    void Awake()
    {
        allEnemies = new List<GameObject>();
        allAllies = new List<GameObject>();
        //DEBUG this
        //TODO remove icitte quand on a les kingdoms
        GameManager.playerKingdom = new Kingdom();
        //GameManager.fightOpponent = new KingdomAlien();
        GameManager.playerKingdom.Units = new List<Unit>(){new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1)};
        GameManager.fightOpponent.Units = new List<Unit>(){new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1),new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1),new Unit(baseFighterPrefab.GetComponent<SpriteRenderer>().sprite,10,3,1)};
        //Enemy
        spawnFighters(GameManager.fightOpponent,enSpawner,allEnemies,true);

        //Allies
        spawnFighters(GameManager.playerKingdom,allySpawner,allAllies);
    }
    void spawnFighters(Kingdom kingdom, GameObject spawner,List<GameObject> allSpawned,bool flipSprite = false)
    {
        Vector3 spawnerPos=spawner.GetComponent<Transform>().position;

        float rectWidth = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.x*spawner.GetComponent<Transform>().localScale.x;
        float rectHeight = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.y*spawner.GetComponent<Transform>().localScale.y;
        
        List<Unit> units = kingdom.Units;
        for (int i = 0; i < units.Count; i++)
        {
            Unit toInstantiate = units[i];
            
            float xPos = spawnerPos.x + Random.Range(-rectHeight, rectHeight);
            float yPos = spawnerPos.z + Random.Range(-rectWidth, rectWidth);
            
            GameObject currFighter = Instantiate(baseFighterPrefab);
            currFighter.GetComponent<Fighter>().Damage = toInstantiate.Damage;
            currFighter.GetComponent<Fighter>().Life = toInstantiate.Hp;
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
        
    }
}
