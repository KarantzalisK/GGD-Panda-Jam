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
    [HideInInspector]
    public bool canSpawn = true;
    [HideInInspector]
    public int i = 0, amountOfEnemies = 0, waveNumber = 0,amountOfEasiestEnemy;
    private int  enemyIndexer;
    public GameObject[] enemyPrefabs;


    void Start()
    {
        waveNumber = 0;
    }

    void Update()
    {
        amountOfEasiestEnemy = activeWave[waveNumber].amountOfFirstEnemyType;
        amountOfEnemies = activeWave[waveNumber].maxEnemies;
        instanciateDelay = activeWave[waveNumber].enemySpawningRate;

        timeCounter += Time.deltaTime;
        if (canSpawn)
        {
            enemySelector();
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
       activeWave[waveNumber].currentEnemies.Add(Instantiate(enemyPrefabs[enemyIndexer], gameObject.transform.position, Quaternion.identity));
    }
    private void enemySelector()
    {
        if (i < amountOfEasiestEnemy)
        {
            enemyIndexer = 0;
        }
         if (i>amountOfEasiestEnemy && i <= amountOfEnemies)
        {
            enemyIndexer = 1;
        }
    }

}


