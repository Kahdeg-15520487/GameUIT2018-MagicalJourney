using UnityEngine;

public static class ExtensionMethod
{
    public static Vector2Int GetNearbyPoint(this Vector2Int vt, Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return vt - new Vector2Int(0, 1);

            case Direction.Down:
                return vt + new Vector2Int(0, 1);

            case Direction.Left:
                return vt - new Vector2Int(1, 0);

            case Direction.Right:
                return vt + new Vector2Int(1, 0);

            default:
                return vt;

        }
    }
}

