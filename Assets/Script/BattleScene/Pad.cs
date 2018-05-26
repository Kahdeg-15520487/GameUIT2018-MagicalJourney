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

    public bool SpawnProjectile(Projectile projectile)
    {
        projectile.Pad = this;
        EffectList.Add(projectile);
        return true;
    }

    public bool SpawnPanelEffect(Vector2Int coordinate, PanelEffect panelEffect)
    {
        var panel = GetPanel(coordinate);
        if (panel == null)
        {
            return false;
        }
        panel.PanelEffect = panelEffect;
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
