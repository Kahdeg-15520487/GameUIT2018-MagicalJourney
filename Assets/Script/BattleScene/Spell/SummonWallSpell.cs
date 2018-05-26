using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonWallSpell : SpellCard
{
    public SummonWallSpell()
    {
        Cooldown = 0;
        BaseCooldown = 10;
        ManaCost = 18;
    }

    public override bool Cast(ISpellCaster caster, Pad pad, Vector2Int coordinate, bool flip = false)
    {
        if (CheckCast(caster))
        {
            var target = GetCastRange(coordinate)[0];
            Debug.Log(target);
            if (!pad.SpawnWall(target))
            {
                caster.SetMana(-ManaCost);
                Cooldown = BaseCooldown;
            }
            return true;
        }
        return false;
    }

    public override List<Vector2Int> GetCastRange(Vector2Int casterPosition, bool flip = false)
    {
        return new List<Vector2Int>() { casterPosition + new Vector2Int(1, 0) };
    }
}
