using UnityEngine;


public class Panel : MonoBehaviour
{
    public Vector2Int Coordinate;

    private IPanelObject panelObject = null;
    public IPanelObject PanelObject
    {
        get
        {
            return panelObject;
        }
        set
        {
            if (value == null)
            {
                panelObject = null;
            }
            else
            {
                panelObject = value;
                panelObject.SetPanel(this);
                panelObject.SetCoordinate(Coordinate);
            }
        }
    }

    private PanelEffect panelEffect = null;
    public PanelEffect PanelEffect
    {
        get
        {
            return panelEffect;
        }
        set
        {
            if (value == null)
            {
                panelEffect = null;
            }
            else
            {
                panelEffect = value;
                panelEffect.SetPanel(this);
            }
        }
    }

    public static Texture2D square;

    //public Panel(Vector2Int coordinate)
    //{
    //    Coordinate = coordinate;
    //}

    //public Panel(int x, int y)
    //{
    //    Coordinate = new Vector2Int(x, y);
    //}

    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (panelObject != null)
        {
            panelObject.UpdateObject();
        }

        if (panelEffect != null)
        {
            panelEffect.Update();
        }
    }
}
