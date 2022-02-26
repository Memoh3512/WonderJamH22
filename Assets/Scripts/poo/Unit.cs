using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    private Sprite sprite;
    private int hp;
    private int damage;
    private float scale;

    public Unit(Sprite sprite, int hp, int damage, int scale)
    {
        this.Sprite = sprite;
        this.Hp = hp;
        this.Damage = damage;
        this.Scale = scale;
    }

    public Sprite Sprite { get => sprite; set => sprite = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Scale { get => scale; set => scale = value; }
}