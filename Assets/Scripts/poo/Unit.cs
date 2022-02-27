using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    private Sprite sprite;
    private int hp;
    private int damage;
    private float scale;
    private int mpValue;

    public Unit(Sprite sprite, int hp, int damage, int scale,int mpValue = 1)
    {
        this.Sprite = sprite;
        this.Hp = hp;
        this.Damage = damage;
        this.Scale = scale;
        this.mpValue = mpValue;
    }

    public Unit(Unit unit)
    {
        this.sprite = unit.sprite;
        this.hp = unit.hp;
        this.damage = unit.damage;
        this.scale = unit.scale;
        this.mpValue = unit.mpValue;
    }

    public Sprite Sprite { get => sprite; set => sprite = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Scale { get => scale; set => scale = value; }
    public int MpValue { get => mpValue; set => mpValue = value; }
}
