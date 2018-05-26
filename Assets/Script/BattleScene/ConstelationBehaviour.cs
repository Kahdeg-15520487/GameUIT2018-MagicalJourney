using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationBehaviour : MonoBehaviour
{
    public GestureScript GestureScript;
    public GameObject Drawer;
    public Player Player;
    public GameObject dimmer;
    public GameObject text;
    public GameObject star;
    public MonsterSpawner MonsterSpawner;
    public GameObject Pad;

    public bool isInContelation = false;

    public void BeginContelation()
    {
        if (Player.SP >= 100)
        {
            GestureScript.gameObject.SetActive(true);
            Drawer.SetActive(true);
            dimmer.SetActive(true);

            Player.gameObject.GetComponent<Player>().enabled = false;
            Pad.GetComponent<Pad>().enabled = false;

            foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                var s = go.GetComponent<Slime>();
                if (s != null)
                {
                    s.enabled = false;
                    s.IsEnabled = false;
                }
            }

            Vector3 vt = new Vector3(0, 0, -5);

            Instantiate(star, vt, transform.rotation);
            Instantiate(star, vt + new Vector3(1, 1), transform.rotation);
            Instantiate(star, vt + new Vector3(-5, 1), transform.rotation);
            Instantiate(star, vt + new Vector3(5, -1), transform.rotation);
            Instantiate(star, vt + new Vector3(-3, -1), transform.rotation);
            Instantiate(star, vt + new Vector3(3, -1), transform.rotation);
            Instantiate(text, vt, transform.rotation);

            isInContelation = true;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInContelation)
        {
            if (GestureScript.Success)
            {
                GestureScript.gameObject.SetActive(false);
                Drawer.SetActive(false);
                dimmer.SetActive(false);

                Player.gameObject.GetComponent<Player>().enabled = true;
                Pad.GetComponent<Pad>().enabled = true;

                foreach (var go in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    var s = go.GetComponent<Slime>();
                    if (s != null)
                    {
                        s.enabled = true;
                        s.IsEnabled = true;
                        MonsterSpawner.ClearWave();
                    }
                }

                isInContelation = false;
            }
        }
    }
}
