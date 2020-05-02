using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class waypointList 
{
    public List<GameObject> waypoints;
}
[System.Serializable]
public class enemiesWaveList
{
    public List<GameObject> enemiesWaveArranger;
}

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyObj;
    public int wavecount = 1,maxEnemies;
    public int[] setEnemiesPerWave;
    private bool canInstansiate = true;
    [SerializeField]
    public List<waypointList> enemyPaths;
    [SerializeField]
    public List<enemiesWaveList>  enemieslist;

    // Start is called before the first frame update
    void Start()
    {
        }

        // Update is called once per frame
        void Update()
        {
           if (wavecount == 1)
        {
            wavecount = 1;
            enemyInstancing();

        }
        }
        void enemyInstancing()
        {
            if ( canInstansiate)
        {
           
                for (int i = 0; i <= setEnemiesPerWave[wavecount-1]; i++)
                {  
                   Instantiate(enemyObj,(enemyPaths[0].waypoints[0].transform));
                
                    Debug.Log(i + "yparxv");
                    if (i >= setEnemiesPerWave[wavecount])
                    {
                        canInstansiate = false;
                    }


                }

            }
        }

    }

