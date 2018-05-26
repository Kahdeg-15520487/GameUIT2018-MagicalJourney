using System.Collections.Generic;

using UnityEngine;

class FirePitSpell : SpellCard
{
    public FirePitSpell(float baseDamage)
    {
        this.BaseDamage = baseDamage;
        BaseCooldown = 5;
        ManaCost = 10;
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate,bool flip = false)
    {
        if (CheckCast(caster))
        {
            var target = GetCastRange(coordinate, flip)[0];
            Debug.Log(target + " " + flip);
            pad.SpawnPanelEffect(target, new BurnPanelEffect(BaseDamage));
            return true;
        }
        return false;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition,bool flip = false)
    {
        if (!flip)
        {
            return new List<Vector2Int>() { casterPosition + new Vector2Int(3, 0) };
        }
        else
        {
            return new List<Vector2Int>() { casterPosition - new Vector2Int(3, 0) };
        }
    }
}
