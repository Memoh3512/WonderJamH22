using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private int life = 10;
    private int damage = 3;
    private float baseCoolDown = 0.1f;
    private float attackCoolDown;
    private Unit representedUnit;
    private int team = -1; // 0 player, 1 ai
    private GameObject target;
    public List<GameObject> myEnemies;
    public List<GameObject> myAllies;
    public int Team
    {
        get => team;
        set => team = value;
    }
    public Unit RepresentedUnit
    {
        get => representedUnit;
        set => representedUnit = value;
    }
    public int Life
    {
        get => life;
        set => life = value;
    }
    public float BaseCoolDown
    {
        get => baseCoolDown;
        set => baseCoolDown = value;
    }
    public int Damage
    {
        get => damage;
        set => damage = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        attackCoolDown = baseCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCoolDown > 0)
        {
            attackCoolDown-=Time.deltaTime;
        }
        if (target != null)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.Normalize(target.transform.position-transform.position)*(800f * Time.deltaTime));
        }
        else
        {
            getClosestTarget();
        }
    }
    void getDamaged(int hitDamage)
    {
        life -= hitDamage;
        if (life <= 0 && GetComponent<Collider>().enabled)
        {
            GetComponent<Collider>().enabled = false;
            myAllies.Remove(gameObject);
            die();
        }
    }
    void die()
    {
        
        
        //TODO FLO son perso meurt
        //SoundPlayer.instance.PlaySFX(Resources.Load<>());
        switch (team)
        {
            
            case 0: FightManager.soldiersDead++;
                break;
            case 1: FightManager.enemiesDead++;
                break;
            
        }
        //TODO anim death
        Destroy(gameObject);
    }
    private void OnCollisionStay(Collision other)
    {
        //Peut attaquer, un fighterm pis dans lautre equipe
        if (attackCoolDown <= 0 && other.gameObject.GetComponent<Fighter>()!=null && team != other.gameObject.GetComponent<Fighter>().team)
        {
            attack(other.gameObject);
        }
    }
    private void attack(GameObject toAttack)
    {
        //Debug.Log("Attacked");
        toAttack.GetComponent<Fighter>().getDamaged(damage);
        attackCoolDown = baseCoolDown;
        getClosestTarget();
    }
    public void getClosestTarget()
    {
        float closestDistance = 99999;
        Vector3 myPos = gameObject.GetComponent<Transform>().position;
        foreach (var enemy in myEnemies)
        {
            Vector3 enPos = enemy.GetComponent<Transform>().position;
            float currEnDistance = Vector3.Distance(myPos, enPos);
            if (currEnDistance < closestDistance)
            {
                target = enemy;
                closestDistance = currEnDistance;
            }
        }
    }
}
