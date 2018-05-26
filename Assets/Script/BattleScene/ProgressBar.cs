using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public UnityEngine.UI.Image Image;
    public UnityEngine.UI.Text Text;

    public void SetPercentage(float f, string s = null)
    {
        Image.fillAmount = f;
        Text.text = s ?? (int)(f * 100) + "%";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
