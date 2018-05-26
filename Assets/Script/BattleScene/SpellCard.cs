using System.Collections.Generic;

using UnityEngine;


public enum Element
{
    Neutral, Fire, Water, Ground, Green, Electric, Wind, Shadow
}

public abstract class SpellCard
{
    public int ManaCost;
    public Element Element;
    public float Cooldown;
    protected float BaseDamage;
    public virtual float GetDamage()
    {
        return BaseDamage;
    }
    public abstract List<Vector2Int> GetCastRange(Vector2Int casterPosition);

    public abstract bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate);
    protected virtual void Act(Panel panel)
    {

    }
}
