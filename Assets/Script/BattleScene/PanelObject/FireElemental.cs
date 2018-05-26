using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElemental : MonoBehaviour, IPanelObject, ISpellCaster, IDamagable
{
    Player Player;
    System.Random random;

    public Element Element { get; set; }
    public Element GetElement() { return Element; }

    private float health = 50;
    public float Health { get { return health; } }
    public float GetHealth() { return health; }
    public float ReceiveDamage(float damage)
    {
        health -= damage;
        Debug.Log("receive " + damage + " damage, " + health + " hp left");
        if (health <= 0)
        {
            if (Dead != null)
            {
                Dead.Invoke(this, null);
            }
        }
        return health;
    }
    public event EventHandler Dead;

    private float mana = 20;
    public float Mana { get { return mana; } }
    public float GetMana() { return mana; }
    public float SetMana(float m) { return mana -= m; }

    private int ap = 5;
    public int AP { get { return ap; } }

    private float sp = 0;
    public float SP { get { return sp; } }

    private float movementCooldown = 0;

    #region Interface
    public Vector2Int Coordinate { get; private set; }

    public Vector2Int GetCoordinate() { return Coordinate; }
    public void SetCoordinate(Vector2Int coordinate)
    {
        Coordinate = coordinate;
    }

    public Panel Panel { get; set; }
    public void SetPanel(Panel panel)
    {
        Panel = panel;
        transform.position = Panel.transform.position;
        transform.position += new Vector3(0, 0, -1);
    }

    public Pad Pad;
    public void SetPad(Pad pad)
    {
        Pad = pad;
    }

    public void Move(Direction dir)
    {
        Pad.Move(Panel, dir);
    }

    public void Destroy()
    {
        Pad.RemoveObjectFromPanel(this.Panel);
        GameObject.Destroy(this.gameObject);
    }
    #endregion

    public Dictionary<string, SpellCard> SpellBook;
    public string EquippedSpell;

    // Use this for initialization
    void Start()
    {
        Element = Element.Fire;
        random = new System.Random(1);

        SpellBook = new Dictionary<string, SpellCard>();
        SpellBook.Add("FirePit", new FirePitSpell(1));
        SpellBook.Add("FireBall", new FireBallSpell(15));
        EquippedSpell = "FireBall";

        Dead += (o, e) => this.Destroy();

        Coordinate = new Vector2Int(5, 1);

        Pad.SpawnObject(this);

        movementCooldown = 0;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObject();
    }

    Direction moveDir = Direction.Left;

    public void UpdateObject()
    {
        mana += 1 / Time.deltaTime * 1;

        movementCooldown += Time.deltaTime;
        if (movementCooldown > 2f)
        {
            if (moveDir == Direction.Left && Coordinate.x == 3)
            {
                moveDir = Direction.Right;
            }
            else if (moveDir == Direction.Right && Coordinate.x == 5)
            {
                moveDir = Direction.Left;
            }

            Move(moveDir);

            movementCooldown = 0;
        }

        if (Player.Coordinate.y == Coordinate.y)
        {
            EquippedSpell = "FireBall";
        }
        else if (Player.Coordinate == Coordinate - new Vector2Int(3, 0))
        {
            EquippedSpell = "FirePit";
        }

        if (EquippedSpell != null && moveDir != Direction.Left)
        {
            if (SpellBook[EquippedSpell].Cast(this, Pad, Coordinate, true))
            {
                Debug.Log("fe cast " + EquippedSpell);
            }
            EquippedSpell = null;
        }

        foreach (var spell in SpellBook.Values)
        {
            spell.Update();
        }
    }
}
