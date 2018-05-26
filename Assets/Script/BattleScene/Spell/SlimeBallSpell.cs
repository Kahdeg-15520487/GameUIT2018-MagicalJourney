using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBallSpell : SpellCard
{

    public SlimeBallSpell(float baseDamage)
    {
        BaseDamage = baseDamage;
        Element = Element.Neutral;
        ManaCost = 10;
        BaseCooldown = 10;
    }

    public override float GetDamage(Element other)
    {
        return DamageCalculator.CalculateDamage(BaseDamage, Element, other);
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate, bool flip = false)
    {
        if (CheckCast(caster))
        {
            var target = GetCastRange(coordinate, flip)[0];
            pad.SpawnProjectile(new BasicProjectile(target, Act, flip),flip);
            return true;
        }
        return false;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition, bool flip = false)
    {
        if (!flip)
        {
            return new List<Vector2Int>() { casterPosition + new Vector2Int(1, 0) };
        }
        else
        {
            return new List<Vector2Int>() { casterPosition - new Vector2Int(1, 0) };
        }
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
