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
    }

    public override float GetDamage(Element other)
    {
        return DamageCalculator.CalculateDamage(BaseDamage, Element, other);
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate)
    {
        //check mana cost

        if (caster.GetMana() < ManaCost)
        {
            return false;
        }

        var target = GetCastRange(coordinate)[0];
        pad.SpawnProjectile(new FireBallProjectile(target, Act));
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
