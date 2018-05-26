using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator
{

    public static float CalculateDamage(float damage, Element caster, Element defender)
    {
        Debug.Log(string.Format("{0} -> {1} = {2}", caster, defender, damage * caster.GetDamageMultiplier(defender)));
        return damage * caster.GetDamageMultiplier(defender);
    }

    public static float GetDamageMultiplier(this Element caster, Element defender)
    {
        var result = 1f;

        switch (caster)
        {
            case Element.Neutral:
                break;
            case Element.Fire:
                if (defender == Element.Green)
                {
                    result = 2;
                }
                break;
            case Element.Water:
                if (defender == Element.Fire)
                {
                    result = 2;
                }
                else if (defender == Element.Green)
                {
                    result = 0.5f;
                }
                break;
            case Element.Ground:
                if (defender == Element.Electric)
                {
                    result = 2;
                }
                break;
            case Element.Green:
                if (defender == Element.Water)
                {
                    result = 2;
                }
                break;
            case Element.Electric:
                if (defender == Element.Water)
                {
                    result = 2;
                }
                else if (defender == Element.Ground)
                {
                    result = 0.5f;
                }
                break;
            case Element.Wind:
                break;
            case Element.Shadow:
                break;
            default:
                break;
        }

        return result;
    }

}
