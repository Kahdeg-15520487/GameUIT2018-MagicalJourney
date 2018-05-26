using System;
using System.Collections.Generic;

using UnityEngine;

class MagicMissileSpell : SpellCard
{
    public MagicMissileSpell(float baseDamage)
    {
        BaseDamage = baseDamage;
        ManaCost = 5;
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
        pad.SpawnProjectile(new BasicProjectile(target, Act));
        return true;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition)
    {
        return new List<Vector2Int>() { casterPosition + new Vector2Int(1, 0) };
    }

    protected override void Act(Panel panel)
    {
        var obj = panel.PanelObject as IDamagable;

        if (obj == null)
        {
            return;
        }

        var result = obj.ReceiveDamage(GetDamage(obj.GetElement()));
    }
}
