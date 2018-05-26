using System;

using UnityEngine;


public class BasicProjectile : Projectile
{
    Action<Panel> Callback;
    public BasicProjectile(Vector2Int coord, Action<Panel> callback = null,bool flip = false)
    {
        Coordinate = coord;
        Duration = 0;
        BaseDuration = 5;
        PanelDuration = 0;
        BasePanelDuration = 0.1f;

        Callback = callback;
        Flip = flip;
    }

    public override void DoEffect(Panel panel)
    {
        panel.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        //panel.color = Color.Yellow;

        if (panel.PanelObject != null)
        {
            //Pad.RemoveObjectFromPanel(panel);
            if (Callback != null)
            {
                Callback.Invoke(panel);
            }
            End();
        }
    }

    public override void UndoEffect(Panel panel)
    {
        panel.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //panel.color = Color.Gray;
    }

    public override Vector2Int NextPanel()
    {
        if (!Flip)
        {
            return Coordinate += new Vector2Int(1, 0);
        }
        else
        {
            return Coordinate -= new Vector2Int(1, 0);
        }
    }
}
