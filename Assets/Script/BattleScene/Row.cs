using UnityEngine;

public class Row : MonoBehaviour
{
    public Panel[] Panels;

    //public Row(int panelPerRow, int rowCoord)
    //{
    //    Panels = new Panel[panelPerRow];
    //    for (int i = 0; i < panelPerRow; i++)
    //    {
    //        Panels[i] = new Panel(i, rowCoord);
    //    }
    //}

    public void Start()
    {

    }

    public void Update()
    {
        foreach (var panel in Panels)
        {
            panel.Update();
        }
    }
}
