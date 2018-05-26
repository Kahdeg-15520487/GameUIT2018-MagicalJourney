using System.Collections.Generic;


using System;
using UnityEngine;

public enum Direction
{
    None = -1,
    Up, Down, Left, Right
}

public class Consumable
{
    bool isUsed = false;
    float HP = 0;
    float MP = 0;
    public Consumable(float hp = 0, float mp = 0)
    {
        HP = hp;
        MP = mp;
        isUsed = false;
    }

    public void Consume(Player player)
    {
        if (!isUsed)
        {
            player.Health += HP;
            player.Mana += MP;
            isUsed = true;
        }
    }
}

public class Player : MonoBehaviour, IPanelObject, ISpellCaster, IDamagable
{
    public UnityEngine.UI.Image ConsumableButton1;
    public UnityEngine.UI.Image ConsumableButton2;
    public UnityEngine.UI.Image ConsumableButton3;
    public Consumable[] Consumables = new Consumable[3];
    public void ConsumeConsumable1()
    {
        if (Consumables[0] != null)
        {
            Consumables[0].Consume(this);
            var color = ConsumableButton1.color;
            ConsumableButton1.color = new Color(color.r, color.g, color.b, 0);
        }
    }
    public void ConsumeConsumable2()
    {
        if (Consumables[1] != null)
        {
            Consumables[1].Consume(this);
            var color = ConsumableButton2.color;
            ConsumableButton2.color = new Color(color.r, color.g, color.b, 0);
        }
    }
    public void ConsumeConsumable3()
    {
        if (Consumables[2] != null)
        {
            Consumables[2].Consume(this);
            var color = ConsumableButton3.color;
            ConsumableButton3.color = new Color(color.r, color.g, color.b, 0);
        }
    }

    public ProgressBar StarPointBar;
    public ProgressBar HPBar;
    public ProgressBar MPBar;

    public UnityEngine.UI.Image CastButton;
    public Sprite[] SpellcardsSprite;

    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer;

    float spriteTimer = 0;
    int currentSprite = 0;

    public Element Element { get; set; }
    public Element GetElement() { return Element; }

    private float health = 500;
    public float Health { get { return health; } set { health = value; } }
    public float GetHealth() { return health; }
    public float ReceiveDamage(float damage)
    {
        health -= damage;
        sp -= 10;
        stopSP = true;
        accelerateSP = false;
        if (sp < 0)
        {
            sp = 0;
        }
        if (health <= 0)
        {
            if (Dead != null)
            {
                Dead.Invoke(this, null);
            }
        }
        return health;
    }

    private float mana = 20;
    public float Mana { get { return mana; } set { mana = value; } }
    public float GetMana() { return mana; }
    public float SetMana(float m) { return mana -= m; }

    private int ap = 5;
    public int AP { get { return ap; } }

    private float sp = 0;
    public float SP { get { return sp; } set { sp = value; } }

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
        if (movementQueue.Count < 2)
        {
            movementQueue.Enqueue(dir);
        }

    }

    public void Destroy()
    {
        Pad.RemoveObjectFromPanel(this.Panel);
        SpriteRenderer.enabled = false;
    }
    #endregion

    public Dictionary<string, SpellCard> SpellBook;
    public string EquippedSpell;

    public void Start()
    {
        Element = Element.Neutral;

        SpellBook = new Dictionary<string, SpellCard>();
        SpellBook.Add("MagicMissile", new MagicMissileSpell(7));
        SpellBook.Add("FirePit", new FirePitSpell(1));
        SpellBook.Add("FireBall", new FireBallSpell(150));
        SpellBook.Add("SummonWall", new SummonWallSpell());
        EquippedSpell = "MagicMissile";
        CastButton.sprite = SpellcardsSprite[0];

        Dead += (o, e) => this.Destroy();

        Coordinate = new Vector2Int(1, 1);

        Pad.SpawnObject(this);

        movementCooldown = 0;

        //load equipment data

        //load consumable data
        var con1 = PlayerPrefs.GetString("Consumable1");
        var con2 = PlayerPrefs.GetString("Consumable2");
        var con3 = PlayerPrefs.GetString("Consumable3");

        if (!string.IsNullOrEmpty(con1))
        {
            Consumables[0] = new Consumable(10, 10);
            ConsumableButton1.sprite = Resources.Load<Sprite>("Item/" + con1);
        }

        if (!string.IsNullOrEmpty(con2))
        {
            Consumables[1] = new Consumable(10, 10);
            ConsumableButton2.sprite = Resources.Load<Sprite>("Item/" + con2);
        }

        if (!string.IsNullOrEmpty(con3))
        {
            Consumables[2] = new Consumable(10, 10);
            ConsumableButton3.sprite = Resources.Load<Sprite>("Item/" + con3);
        }
    }

    private Queue<Direction> movementQueue = new Queue<Direction>(2);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            mana = 200;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            sp = 100;
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
            if (sp < 100)
            {
                if (stopSP)
                {
                    stopSP = false;
                }
                else
                {
                    if (accelerateSP)
                    {
                        sp += 5;
                    }
                    else sp += 1;
                }
            }
            if (mana < 20)
            {
                mana += 2f;
            }

            if (sp > 100)
            {
                sp = 100;
            }

            if (mana > 20)
            {
                mana = 20;
            }
            timer = 0;
        }

        timer5 += Time.deltaTime;
        if (timer5 > 5)
        {
            if (stopSP == false)
            {
                accelerateSP = true;
            }
            timer5 = 0;
        }

        StarPointBar.SetPercentage(sp / 100, sp.ToString());
        HPBar.SetPercentage(health / 500, health + "/" + 500);
        MPBar.SetPercentage(mana / 20, mana + "/" + 20);
    }

    float timer = 0;
    float timer5 = 0;
    bool stopSP = false;
    bool accelerateSP = false;

    public void UpdateObject()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetSpellMagicmissile();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SetSpellFireball();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SetSpellFirepit();
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SetSpellSummonwall();
        }

        GetInput();

        movementCooldown += Time.deltaTime;
        if (movementCooldown > 0.25f)
        {
            Direction moveDir = Direction.None;
            if (movementQueue.Count > 0)
            {
                moveDir = movementQueue.Dequeue();
            }
            bool isMoved = true;

            if (moveDir != Direction.None)
            {
                if (moveDir == Direction.Right && Coordinate.x == 2)
                {

                }
                else Pad.Move(Panel, moveDir);
            }
            else isMoved = false;

            if (isMoved)
            {
                movementCooldown = 0;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Fire();
            }
        }

        foreach (var spell in SpellBook.Values)
        {
            spell.Update();
        }
    }

    public void SetSpellMagicmissile()
    {
        EquippedSpell = "MagicMissile";
        CastButton.sprite = SpellcardsSprite[0];
    }

    public void SetSpellFireball()
    {
        EquippedSpell = "FireBall";
        CastButton.sprite = SpellcardsSprite[1];
    }

    public void SetSpellFirepit()
    {
        EquippedSpell = "FirePit";
        CastButton.sprite = SpellcardsSprite[2];
    }

    public void SetSpellSummonwall()
    {
        EquippedSpell = "SummonWall";
        CastButton.sprite = SpellcardsSprite[3];
    }

    public void MoveLeft()
    {
        Move(Direction.Left);
    }

    public void MoveRight()
    {
        Move(Direction.Right);
    }

    public void MoveUp()
    {
        Move(Direction.Up);
    }

    public void MoveDown()
    {
        Move(Direction.Down);
    }

    public void Fire()
    {
        if (SpellBook[EquippedSpell].Cast(this, Pad, Coordinate, false))
        {
            Debug.Log("player cast " + EquippedSpell);
            currentSprite = 1;
            SpriteRenderer.sprite = Sprites[currentSprite];
        }
    }

    void GetInput()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Move(Direction.Left);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Move(Direction.Right);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Move(Direction.Up);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Move(Direction.Down);
        }
    }

    public event EventHandler Dead;
}
