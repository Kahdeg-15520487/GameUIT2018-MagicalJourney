using System.Collections.Generic;


using System;
using UnityEngine;

public enum Direction
{
    None = -1,
    Up, Down, Left, Right
}

public class Player : MonoBehaviour, IPanelObject, ISpellCaster, IDamagable
{
    public ProgressBar StarPointBar;
    public ProgressBar HPBar;
    public ProgressBar MPBar;

    public UnityEngine.UI.Text CastButton;

    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer;

    float spriteTimer = 0;
    int currentSprite = 0;

    public Element Element { get; set; }
    public Element GetElement() { return Element; }

    private float health = 500;
    public float Health { get { return health; } }
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
    public float Mana { get { return mana; } }
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
        CastButton.text = EquippedSpell;

        Dead += (o, e) => this.Destroy();

        Coordinate = new Vector2Int(1, 1);

        Pad.SpawnObject(this);

        movementCooldown = 0;
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

        StarPointBar.SetPercentage(sp / 100);
        HPBar.SetPercentage(health / 500);
        MPBar.SetPercentage(mana / 20);
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

    public void SetSpellFireball()
    {
        EquippedSpell = "FireBall";
        CastButton.text = EquippedSpell;
    }

    public void SetSpellFirepit()
    {
        EquippedSpell = "FirePit";
        CastButton.text = EquippedSpell;
    }

    public void SetSpellSummonwall()
    {
        EquippedSpell = "SummonWall";
        CastButton.text = EquippedSpell;
    }

    public void SetSpellMagicmissile()
    {
        EquippedSpell = "MagicMissile";
        CastButton.text = EquippedSpell;
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
