using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreFunctions : MonoBehaviour
{
    [SerializeField]
    BallController playerStats;

    string playerName;
    string hitCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SaveOrLoadPlayerInfo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SaveOrLoadPlayerInfo()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Saving player info...");
                string filepath = Environment.CurrentDirectory+"\\playerSave.txt";

                try
                {
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }

                    using(StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(playerStats.PlayerName.ToString());
                        sw.WriteLine(playerStats.hitCount.ToString());
                    }

                }
                catch(Exception ex)
                {
                    Debug.Log("something went wrong while writing player stats");
                    Debug.Log(ex);
                }

                Debug.Log("main directory is: " + Environment.CurrentDirectory);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("loading player data");
                string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\playerSave.txt");
                 
                playerStats.PlayerName = lines[0];
                playerStats.hitCount = Int32.Parse(lines[1]);

            }
            yield return null;
        }
    }
}
