using UnityEngine;

public class Row : MonoBehaviour
{
    public float Spacing = 1.5f;

    public Panel[] Panels;
    public GameObject PanelPrefab;

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
        //Panels = new Panel[6];
        //for (int i = 0; i < 6; i++)
        //{
        //    var panel = Instantiate(PanelPrefab, transform);
        //    panel.transform.position = transform.position + new Vector3(i, 0) * Spacing;
        //    Panels[i] = panel.GetComponent<Panel>();
        //}
    }

    public void Update()
    {
        foreach (var panel in Panels)
        {
            panel.Update();
        }
    }
}
