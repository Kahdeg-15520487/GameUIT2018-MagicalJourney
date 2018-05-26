using UnityEngine;

public abstract class Projectile
{
    /// <summary>
    /// the pad that this effect is on
    /// </summary>
    public Pad Pad { get; set; }

    /// <summary>
    /// how long has this effect been since activation
    /// </summary>
    public float Duration { get; set; }
    /// <summary>
    /// how long should this effect stay
    /// </summary>
    public float BaseDuration { get; protected set; }

    /// <summary>
    /// how long has this effect been since enter current panel
    /// </summary>
    public float PanelDuration { get; set; }
    /// <summary>
    /// how long should this effect move to next panel
    /// </summary>
    public float BasePanelDuration { get; protected set; }

    /// <summary>
    /// where is this effect
    /// </summary>
    public Vector2Int Coordinate { get; set; }

    /// <summary>
    /// do something on a panel
    /// </summary>
    /// <param name="panel"></param>
    public abstract void DoEffect(Panel panel);
    /// <summary>
    /// undo something on a panel
    /// </summary>
    /// <param name="panel"></param>
    public abstract void UndoEffect(Panel panel);

    /// <summary>
    /// flip the direction of the travel;
    /// </summary>
    public bool Flip;
    /// <summary>
    /// get the next panel
    /// </summary>
    public abstract Vector2Int NextPanel();

    public GameObject BulletObject;

    /// <summary>
    /// end the effect immediately
    /// </summary>
    public virtual void End()
    {
        Duration = BaseDuration + 1;
        if (BulletObject != null)
        {
            GameObject.Destroy(BulletObject);
        }
    }
}
