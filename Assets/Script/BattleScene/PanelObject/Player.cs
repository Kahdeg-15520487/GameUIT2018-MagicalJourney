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
    public Element Element { get; set; }
    public Element GetElement() { return Element; }

    private float health = 50;
    public float Health { get { return health; } }
    public float GetHealth() { return health; }
    public float ReceiveDamage(float damage)
    {
        health -= damage;
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
        if (movementQueue.Count < 2)
        {
            movementQueue.Enqueue(dir);
        }

    }

    public void Destroy()
    {
        Pad.RemoveObjectFromPanel(this.Panel);
    }
    #endregion

    public Dictionary<string, SpellCard> SpellBook;
    public string EquippedSpell;

    public void Start()
    {
        Element = Element.Neutral;

        SpellBook = new Dictionary<string, SpellCard>();
        SpellBook.Add("MagicMissile", new MagicMissileSpell(10));
        SpellBook.Add("FirePit", new FirePitSpell(1));
        SpellBook.Add("FireBall", new FireBallSpell(15));
        EquippedSpell = "MagicMissile";

        Dead += (o, e) => this.Destroy();

        Coordinate = new Vector2Int(1, 1);

        Pad.SpawnObject(this);

        movementCooldown = 0;
    }

    private Queue<Direction> movementQueue = new Queue<Direction>(2);

    // Update is called once per frame
    void Update()
    {
        UpdateObject();
    }

    public void UpdateObject()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            EquippedSpell = "MagicMissile";
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            EquippedSpell = "FirePit";
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            EquippedSpell = "FireBall";
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
                SpellBook[EquippedSpell].Cast(this, Pad, Coordinate);
            }
        }
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
        SpellBook[EquippedSpell].Cast(this, Pad, Coordinate);
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
