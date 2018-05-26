using System.Collections.Generic;

using UnityEngine;

class FirePitSpell : SpellCard
{
    public FirePitSpell(float baseDamage)
    {
        this.BaseDamage = baseDamage;
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate)
    {
        //check for mana cost, cooldown stuff
        //not enough -> return false;

        if (caster.GetMana() < ManaCost)
        {
            return false;
        }
        var target = GetCastRange(coordinate)[0];
        pad.SpawnPanelEffect(target, new BurnPanelEffect(GetDamage()));
        return true;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition)
    {
        return new List<Vector2Int>() { casterPosition + new Vector2Int(3, 0) };
    }
}
