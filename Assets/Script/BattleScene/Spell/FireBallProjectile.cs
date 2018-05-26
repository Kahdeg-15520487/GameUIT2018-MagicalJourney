using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : BasicProjectile
{
    public FireBallProjectile(Vector2Int coord, Action<Panel> callback = null,bool flip = false) : base(coord, callback,flip)
    {
    }
}
