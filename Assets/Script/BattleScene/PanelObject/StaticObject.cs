using System;
using UnityEngine;

class StaticObject : MonoBehaviour, IPanelObject, IDamagable
{
    public Sprite[] Sprites;
    public SpriteRenderer SpriteRenderer;

    float spriteTimer = 0;
    int currentSprite = 0;

    public Element Element;
    public Element GetElement() { return Element; }

    private float health = 30;
    public float Health { get { return health; } }
    public float GetHealth() { return health; }
    public float ReceiveDamage(float damage)
    {
        Debug.Log("receive " + damage + " damage, " + health + " hp left");
        health -= damage;
        if (health > 20)
        {
            currentSprite = 0;
        }
        else if (health > 10 && health < 20)
        {
            currentSprite = 1;
        }
        else
        {
            currentSprite = 2;
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

    public string Name { get; set; }

    public void Start()
    {
        Element = Element.Ground;
        Dead += (o, e) => this.Destroy();

        Pad.SpawnObject(this);
    }

    #region interface

    public Vector2Int Coordinate { get; private set; }

    public Vector2Int GetCoordinate() { return Coordinate; }

    public void Move(Direction dir)
    {
        Pad.Move(Panel, dir);
    }

    public void SetCoordinate(Vector2Int coordinate)
    {
        Coordinate = coordinate;
    }

    public Pad Pad;
    public void SetPad(Pad pad)
    {
        Pad = pad;
    }

    public Panel Panel { get; private set; }
    public void SetPanel(Panel panel)
    {
        Panel = panel;
        transform.position = Panel.transform.position;
        transform.position += new Vector3(0, 0, -1);
    }

    public void Destroy()
    {
        Pad.RemoveObjectFromPanel(this.Panel);
        Destroy(gameObject);
    }
    #endregion

    void Update()
    {

        SpriteRenderer.sprite = Sprites[currentSprite];
    }

    public void UpdateObject()
    {

    }

    Vector2 drawPos;

    public event EventHandler Dead;

    //public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
    //{
    //    spriteBatch.DrawString(Player.font, $"{Name} {health}", drawPos, Color.Yellow, 0f, Vector2.Zero, 1f, SpriteEffects.None, LayerDepth.Unit);
    //}
}
