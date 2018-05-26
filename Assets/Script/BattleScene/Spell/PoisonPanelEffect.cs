using UnityEngine;

class PoisonPanelEffect : PanelEffect
{
    float Interval;
    float timer;
    public float DamageOverTime { get; private set; }

    public PoisonPanelEffect(float dot = 1)
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
        Panel.SpriteRenderer.color = new Color32(143, 0, 254, 1);
    }

    public override void End()
    {
        base.End();
        Panel.SpriteRenderer.color = Color.white;
    }
}
