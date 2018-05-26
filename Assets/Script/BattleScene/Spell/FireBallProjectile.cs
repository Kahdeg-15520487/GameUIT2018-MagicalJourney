using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : BasicProjectile
{
    public FireBallProjectile(Vector2Int coord, Action<Panel> callback = null,bool flip = false) : base(coord, callback,flip)
    {
    }

    public override void DoEffect(Panel panel)
    {
        base.DoEffect(panel);
    }

    public override void UndoEffect(Panel panel)
    {
        base.UndoEffect(panel);
    }
}
