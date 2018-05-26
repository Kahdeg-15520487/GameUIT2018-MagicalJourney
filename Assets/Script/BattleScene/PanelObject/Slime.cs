using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IPanelObject, ISpellCaster, IDamagable
{
    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer;

    float spriteTimer = 0;
    int currentSprite = 0;

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
        currentSprite = 1;
        SpriteRenderer.sprite = Sprites[currentSprite];
        Debug.Log("receive " + damage + " damage, " + health + " hp left");
        if (health <= 0)
        {
            IsEnabled = false;
            if (Dead != null)
            {
                Dead.Invoke(this, null);
            }
        }
        return health;
    }
    public event EventHandler Dead;

    private float mana = 20;
    public float Mana { get { return 50; } }
    public float GetMana() { return mana; }
    public float SetMana(float m) { return 50; }

    private int ap = 5;
    public int AP { get { return ap; } }

    private float sp = 0;
    public float SP { get { return sp; } }

    private float movementCooldown = 0;

    #region Interface
    public Vector2Int Coordinate;

    public Vector2Int GetCoordinate() { return Coordinate; }
    public void SetCoordinate(Vector2Int coordinate)
    {
        Coordinate = coordinate;
    }

    public Panel Panel { get; set; }
    bool isRunAway = false;
    public bool IsRunAway { get { return isRunAway; } set { isRunAway = value; } }

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
        currentSprite = 2;
        spriteTimer = -1000;
        SpriteRenderer.sprite = Sprites[currentSprite];
    }
    #endregion

    public Dictionary<string, SpellCard> SpellBook;
    public string EquippedSpell;

    // Use this for initialization
    void Start()
    {
        Element = Element.Neutral;
        random = new System.Random(1);

        SpellBook = new Dictionary<string, SpellCard>();
        SpellBook.Add("SlimePit", new SlimePitSpell(1));
        SpellBook.Add("SlimePunch", new SlimeBallSpell(15));
        EquippedSpell = "SlimePunch";

        Dead += (o, e) => this.Destroy();

        Pad.SpawnObject(this);

        movementCooldown = 0;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        IsEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunAway)
        {
            transform.position += new Vector3(1, 1) * 5 * Time.deltaTime;
        }

        if (!IsEnabled)
        {
            return;
        }

        UpdateObject();

        if (currentSprite != 0)
        {
            spriteTimer += Time.deltaTime;
            if (spriteTimer > 0.5f)
            {
                currentSprite = 0;
                spriteTimer = 0;
                SpriteRenderer.sprite = Sprites[currentSprite];
            }
        }

        timer += Time.deltaTime;
        if (timer > 1)
        {
            if (mana < 20)
            {
                mana += 0.2f;
            }
            timer = 0;
        }
    }

    float timer = 0;

    Direction moveDir = Direction.Left;
    public bool IsEnabled = true;

    public void UpdateObject()
    {
        if (!IsEnabled)
        {
            return;
        }

        if (health > 0)
        {
            movementCooldown += Time.deltaTime;
            if (movementCooldown > 5f)
            {
                if (moveDir == Direction.Left && Coordinate.x == 3)
                {
                    moveDir = Direction.Right;
                }
                else if (moveDir == Direction.Right && Coordinate.x == 5)
                {
                    moveDir = Direction.Left;
                }

                if (health > 0)
                {
                    Move(moveDir);
                }

                movementCooldown = 0;
            }

            if (Player.Coordinate.y == Coordinate.y)
            {
                EquippedSpell = "SlimePunch";
            }
            else if (Player.Coordinate == Coordinate - new Vector2Int(3, 0))
            {
                EquippedSpell = "SlimePit";
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

    public void Dispel()
    {
        currentSprite = 2;
        spriteTimer = -1000;
        SpriteRenderer.sprite = Sprites[currentSprite];
    }
}
