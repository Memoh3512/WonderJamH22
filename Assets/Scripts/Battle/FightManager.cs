using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField]
    public GameObject enSpawner;
    public GameObject allySpawner;
    public GameObject baseFighterPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        //DEBUG this
        GameManager.playerKingdom = new Kingdom();
        //Enemy
        spawnFighters(GameManager.fightOpponent,enSpawner,true);

        //Allies
        spawnFighters(GameManager.playerKingdom,allySpawner);
    }
    void spawnFighters(Kingdom kingdom, GameObject spawner,bool flipSprite = false)
    {
        Vector3 spawnerPos=spawner.GetComponent<Transform>().position;

        float rectWidth = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.x*spawner.GetComponent<Transform>().localScale.x;
        float rectHeight = spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.y*spawner.GetComponent<Transform>().localScale.y;
        
        List<Unit> units = kingdom.Units;
        for (int i = 0; i < kingdom.MilitaryPower; i++)
        {
            Unit toInstantiate = units[Random.Range(0, units.Count)];
            
            float xPos = spawnerPos.x + Random.Range(-rectHeight, rectHeight);
            float yPos = spawnerPos.z + Random.Range(-rectWidth, rectWidth);
            
            GameObject currFighter = Instantiate(baseFighterPrefab);
            currFighter.GetComponent<Fighter>().Damage = toInstantiate.Damage;
            currFighter.GetComponent<Fighter>().Life = toInstantiate.Hp;
            currFighter.GetComponent<Transform>().localScale = Vector3.one * toInstantiate.Scale;
            currFighter.GetComponent<SpriteRenderer>().sprite = toInstantiate.Sprite;
            
            currFighter.transform.position = new Vector3(xPos, spawnerPos.y+2.25f, yPos);
            if (flipSprite)
                currFighter.GetComponent<SpriteRenderer>().flipX = !currFighter.GetComponent<SpriteRenderer>().flipX;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
