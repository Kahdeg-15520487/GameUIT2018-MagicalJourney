using System;
using System.Collections.Generic;

using UnityEngine;

class MagicMissileSpell : SpellCard
{
    public MagicMissileSpell(float baseDamage)
    {
        BaseDamage = baseDamage;
        BaseCooldown = 5;
        ManaCost = 5;
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate, bool flip = false)
    {
        //check for mana cost, cooldown stuff
        //not enough -> return false;

        if (!CheckCast(caster))
        {
            return false;
        }

        var target = GetCastRange(coordinate, flip)[0];
        pad.SpawnProjectile(new BasicProjectile(target, Act));
        return true;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition, bool flip = false)
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
