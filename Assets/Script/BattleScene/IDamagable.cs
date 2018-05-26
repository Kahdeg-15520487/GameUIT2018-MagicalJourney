using System;

internal interface IDamagable
{
    float GetHealth();
    float ReceiveDamage(float v);

    event EventHandler Dead;
}
