using UnityEngine;

class BurnPanelEffect : PanelEffect
{
    float Interval;
    float timer;
    public float DamageOverTime { get; private set; }

    public BurnPanelEffect(float dot = 1)
    {
        Duration = 0;
        BaseDuration = 5;
        Interval = 0.5f;
        timer = 0;

        DamageOverTime = dot;
    }

    public override void Update()
    {
        Duration += Time.deltaTime;

        timer += Time.deltaTime;
        if (timer > Interval)
        {
            timer = 0;
            var obj = Panel.PanelObject as IDamagable;
            if (obj != null)
            {
                obj.ReceiveDamage(DamageOverTime);
            }
        }
    }
}
