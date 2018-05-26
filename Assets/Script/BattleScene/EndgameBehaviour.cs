using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameBehaviour : MonoBehaviour
{
    public UnityEngine.UI.Text EndgameText;
    public UnityEngine.UI.Image DimScreen;
    public Player Player;
    public GameObject Pad;

    // Use this for initialization
    void Start()
    {
        isEnding = false;
        timer = 0;
    }

    bool isEnding = false;

    public void StartTheEnd()
    {
        isEnding = true;
        EndgameText.gameObject.SetActive(true);
        DimScreen.enabled = true;
        Player.gameObject.GetComponent<Player>().enabled = false;
        Pad.GetComponent<Pad>().enabled = false;

        foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            var s = go.GetComponent<Slime>();
            if (s != null)
            {
                s.IsEnabled = false;
            }
        }
    }

    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Player.Health<=0)
        {
            StartTheEnd();
            EndgameText.text = "You lose!";
        }

        if (isEnding)
        {
            timer += Time.deltaTime;
            if (timer > 10)
            {
                LoaderBehaviour.SceneName = "OverWorldMapScene";
                SceneManager.LoadScene("LoadScreen");
            }
        }
    }
}
