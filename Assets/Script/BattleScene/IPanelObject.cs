using UnityEngine;

public interface IPanelObject
{
    Vector2Int GetCoordinate();
    void Move(Direction dir);
    void SetCoordinate(Vector2Int coordinate);
    void UpdateObject();
    void SetPanel(Panel panel);
    void SetPad(Pad pad);
    void Destroy();
}

