using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private int life = 10;
    private int damage = 3;
    private float baseCoolDown = 1;
    private float attackCoolDown;
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
        
    }
    void getDamaged(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            die();
        }
    }
    void die()
    {
        //TODO anim death
        Destroy(gameObject);
    }
}
