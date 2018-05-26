using System;
using System.Collections.Generic;

using UnityEngine;

public class Pad : MonoBehaviour
{
    public float Spacing = 1.5f;

    public Row[] Rows;

    public List<Projectile> EffectList;
    public GameObject RowPrefab;
    public GameObject PanelPrefab;
    public GameObject WallPrefab;
    public GameObject BulletPrefab;

    public Player Player;

    public bool SpawnWall(Vector2Int coordinate)
    {
        Panel panel = GetPanel(coordinate);

        if (panel != null)
        {
            var wall = Instantiate(WallPrefab);
            panel.PanelObject = wall.GetComponent<IPanelObject>();
            panel.PanelObject.SetPad(this);
            Debug.Log(panel.PanelObject.GetCoordinate());
            return true;
        }
        return false;
    }

    // Use this for initialization
    //public Pad(int rowPerPad, int panelPerRow)
    //{
    //    EffectList = new List<Projectile>();
    //    Rows = new Row[rowPerPad];
    //    for (int i = 0; i < rowPerPad; i++)
    //    {
    //        Rows[i] = new Row(panelPerRow, i);
    //    }
    //}

    void Start()
    {
        EffectList = new List<Projectile>();
        //Rows = new Row[3];
        //for (int i = 0; i < 3; i++)
        //{
        //    var row = Instantiate(RowPrefab, transform);
        //    row.transform.position = transform.position + new Vector3(-7, i) * Spacing;
        //    Rows[i] = row.GetComponent<Row>();
        //    Rows[i].PanelPrefab = PanelPrefab;
        //}
    }

    public bool Move(Panel from, Direction direction)
    {
        if (from.PanelObject == null)
        {
            return false;
        }

        Panel dest = GetPanel(from.Coordinate.GetNearbyPoint(direction));
        if (dest == null)
        {
            return false;
        }

        if (dest.PanelObject != null)
        {
            return false;
        }

        dest.PanelObject = from.PanelObject;
        from.PanelObject = null;
        return true;
    }

    /// <summary>
    /// remove a panel object from a panel
    /// </summary>
    public bool RemoveObjectFromPanel(Panel panel)
    {
        if (panel.PanelObject == null)
        {
            return false;
        }

        if (panel.PanelObject.GetType() == typeof(Slime))
        {
            Player.ReceiveDamage(10);
        }

        panel.PanelObject = null;
        return true;
    }

    public bool SpawnObject(IPanelObject obj)
    {
        var panel = GetPanel(obj.GetCoordinate());
        if (panel == null)
        {
            Debug.Log("null");
            return false;
        }
        panel.PanelObject = obj;
        panel.PanelObject.SetPad(this);
        return true;
    }

    public bool SpawnProjectile(Projectile projectile, bool flip = false)
    {
        projectile.Pad = this;
        EffectList.Add(projectile);
        var bullet = Instantiate(BulletPrefab);
        var bb = bullet.GetComponent<ProjectileBehaviour>();
        var panel = GetPanel(projectile.Coordinate);
        bb.transform.position = panel.transform.position + new Vector3(0, 0, -4);

        if (!flip)
        {
            bb.MovementVector = new Vector3(0.3f, 0, 0);
        }
        else
        {
            bb.transform.rotation = Quaternion.Euler(0, 180, 0);
            bb.MovementVector = new Vector3(-0.3f, 0, 0);
        }
        projectile.BulletObject = bullet;
        return true;
    }

    public bool SpawnPanelEffect(Vector2Int coordinate, PanelEffect panelEffect)
    {
        var panel = GetPanel(coordinate);
        if (panel == null)
        {
            Debug.Log(coordinate);
            return false;
        }
        panel.PanelEffect = panelEffect;
        Debug.Log("lala");
        return true;
    }

    public bool SpawnPanelEffect(Panel panel, PanelEffect panelEffect)
    {
        panel.PanelEffect = panelEffect;
        return true;
    }

    // Update is called once per frame
    public void Update()
    {
        List<Projectile> toBeRemoved = new List<Projectile>();
        foreach (var effect in EffectList)
        {
            effect.Duration += Time.deltaTime;
            effect.PanelDuration += Time.deltaTime;

            var panel = GetPanel(effect.Coordinate);

            effect.DoEffect(panel);

            if (effect.PanelDuration > effect.BasePanelDuration)
            {
                effect.Coordinate = effect.NextPanel();
                effect.PanelDuration = 0;
                effect.UndoEffect(panel);
                if (IsOutOfBound(effect.Coordinate))
                {
                    toBeRemoved.Add(effect);
                }
            }

            if (effect.Duration > effect.BaseDuration)
            {
                effect.UndoEffect(panel);
                toBeRemoved.Add(effect);
            }
        }

        foreach (var tbr in toBeRemoved)
        {
            if (EffectList.Contains(tbr))
            {
                EffectList.Remove(tbr);
            }
        }

        foreach (var row in Rows)
        {
            row.Update();
        }
    }

    private bool IsOutOfBound(Vector2Int coordinate)
    {
        return !(coordinate.y >= 0 && coordinate.y < Rows.Length && coordinate.x >= 0 && coordinate.x < Rows[0].Panels.Length);
    }

    public Panel GetPanel(Vector2Int coordinate)
    {
        return GetPanel(coordinate.x, coordinate.y);
    }

    public Panel GetPanel(int x, int y)
    {
        try
        {
            return Rows[y].Panels[x];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Panel this[int x, int y]
    {
        get { return GetPanel(x, y); }
    }
}
