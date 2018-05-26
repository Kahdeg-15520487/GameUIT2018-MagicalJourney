using UnityEngine;

public abstract class PanelEffect
{
    /// <summary>
    /// the panel that this effect is on
    /// </summary>
    public Panel Panel { get; protected set; }
    public virtual void SetPanel(Panel panel)
    {
        Panel = panel;
    }

    /// <summary>
    /// how long has this effect been since activation (ms)
    /// </summary>
    public float Duration { get; set; }
    /// <summary>
    /// how long should this effect stay (ms)
    /// </summary>
    public int BaseDuration { get; protected set; }

    public virtual void Update()
    {
        Duration += Time.deltaTime;
    }

    /// <summary>
    /// end the effect immediately
    /// </summary>
    public virtual void End()
    {
        Duration = BaseDuration + 1;
    }
}
