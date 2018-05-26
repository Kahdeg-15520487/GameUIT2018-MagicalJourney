using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public EndgameBehaviour EndgameBehaviour;

    public Pad Pad;

    public GameObject SlimePrefab;

    public List<Slime> monsterList = new List<Slime>();

    public List<List<Vector2Int>> WaveConfigs = new List<List<Vector2Int>>()
    {
        new List<Vector2Int>(){new Vector2Int(5,0), new Vector2Int(4, 1), new Vector2Int(3, 2), },
        new List<Vector2Int>(){new Vector2Int(3,0), new Vector2Int(4, 1), new Vector2Int(5, 2), },
    };

    int currentWave = 0;

    // Use this for initialization
    void Start()
    {
        monsterList = new List<Slime>();
    }

    public void SpawnWave()
    {
        foreach (var coord in WaveConfigs[currentWave])
        {
            var slimego = Instantiate(SlimePrefab);
            var slime = slimego.GetComponent<Slime>();
            slime.Coordinate = coord;
            slime.Pad = Pad;
            monsterList.Add(slime);
        }
        currentWave++;
    }

    public bool AllClear()
    {
        return monsterList.TrueForAll(s => s.IsEnabled == false && s.Health <= 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterList.Count == 0 || AllClear())
        {
            ClearWave();
            if (currentWave < WaveConfigs.Count)
            {
                SpawnWave();
            }
            else
            {
                //you won the level, go back to overworld
                EndgameBehaviour.StartTheEnd();
            }
        }
    }

    internal void ClearWave()
    {
        foreach (var slime in monsterList)
        {
            Pad.RemoveObjectFromPanel(slime.Panel);
            GameObject.Destroy(slime.gameObject);
        }
        monsterList = new List<Slime>();
    }
}
