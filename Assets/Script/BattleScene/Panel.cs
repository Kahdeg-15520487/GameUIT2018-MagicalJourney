using UnityEngine;


public class Panel : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Pad pad;

    public static System.Random random = new System.Random(0);

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
        pad = GameObject.FindGameObjectWithTag("Pad").GetComponent<Pad>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        if (Coordinate.x <= 2)
        {
            SpriteRenderer.sprite = pad.GetComponent<PanelSpriteContainer>().PanelSprites[random.Next(0, 3)];
        }
        else
        {
            SpriteRenderer.sprite = pad.GetComponent<PanelSpriteContainer>().PanelSprites[random.Next(4, 6)];
        }

        transform.localScale *= 1.2f;
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
            if (panelEffect.Duration > panelEffect.BaseDuration)
            {
                panelEffect.End();
                panelEffect = null;
            }
        }
    }
}
