using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemyPaths> enemyPaths;

    [SerializeField]
    public List<EnemyWavesParameters> activeWave;
    [HideInInspector]
    public float timeCounter, instanciateDelay;
    //[HideInInspector]
    public bool canSpawn = true;
    public int i = 0, amountOfEnemies = 0, waveNumber = 0;
    private int  enemyIndexer;
    public GameObject[] enemyPrefabs;


    void Start()
    {
        waveNumber = 0;
    }

    void Update()
    {
        amountOfEnemies = activeWave[waveNumber].maxEnemies;
        instanciateDelay = activeWave[waveNumber].enemySpawningRate;

        timeCounter += Time.deltaTime;
        if (canSpawn)
        {
            enemyInstantiateCheck();
        }
       

    }
    private void enemyInstantiateCheck()
    {

        if (i < amountOfEnemies)
        {
            if (timeCounter >= instanciateDelay)
            {
                
                timeCounter = 0;
                i++;
                enemyInstantiatNaddToList();


            }

        }

        else
        {
            canSpawn = false;

        }
    }
    private void enemyInstantiatNaddToList()
    {
        enemyIndexer = UnityEngine.Random.Range(0, activeWave[waveNumber].numberOFenemyTypes);
       activeWave[waveNumber].currentEnemies.Add(Instantiate(enemyPrefabs[enemyIndexer], gameObject.transform.position, Quaternion.identity));
    }


}


