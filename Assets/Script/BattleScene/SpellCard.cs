using System.Collections.Generic;

using UnityEngine;


public enum Element
{
    Neutral,
    Fire, Water,
    Ground, Green,
    Electric,
    Wind, Shadow
}

public abstract class SpellCard
{
    public int ManaCost;
    public Element Element;
    public float Cooldown;
    public float BaseCooldown;
    protected float BaseDamage;
    public virtual float GetDamage(Element other)
    {
        return BaseDamage;
    }
    public abstract List<Vector2Int> GetCastRange(Vector2Int casterPosition,bool flip = false);

    public abstract bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate,bool flip = false);
    protected virtual void Act(Panel panel)
    {

    }

    public void Update()
    {
        Cooldown += Time.deltaTime;
    }
    public bool CheckCast(ISpellCaster caster)
    {
        if (Cooldown > BaseCooldown)
        {
            if (caster.GetMana() > ManaCost)
            {
                Cooldown = 0;
                caster.SetMana(ManaCost);
                return true;
            }
        }

        return false;
    }
}
