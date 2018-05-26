using System;

internal interface IDamagable
{
    Element GetElement();
    float GetHealth();
    float ReceiveDamage(float v);

    event EventHandler Dead;
}
