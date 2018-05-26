using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpell : SpellCard
{

    public FireBallSpell(float baseDamage)
    {
        BaseDamage = baseDamage;
        Element = Element.Fire;
        ManaCost = 10;
        BaseCooldown = 5;
    }

    public override float GetDamage(Element other)
    {
        return DamageCalculator.CalculateDamage(BaseDamage, Element, other);
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate, bool flip = false)
    {
        if (!CheckCast(caster))
        {
            return false;
        }

        var target = GetCastRange(coordinate, flip)[0];
        pad.SpawnProjectile(new FireBallProjectile(target, Act, flip));
        return true;
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
