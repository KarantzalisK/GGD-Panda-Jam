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
    public List<Wave> Waves;

    public float timeCounter, instanciateDelay, waveDelay;
    [HideInInspector]
    public bool canSpawn = true,noEnemiesinList=false;
    public int i = 0, amountOfEnemies=10, enemyIndexer, waveNumber = 1, extraEnemies;
    public GameObject[] enemyPrefabs;
    //public List<GameObject> currentEnemies;


    void Start()
    {
        waveNumber = 1;
    }

    void Update()
    {   
            timeCounter += Time.deltaTime;
        
        enemyInstantiate();

        //private bool subWaveInstanciation(SubWave subWave)
        //{
        //    if (timeCounter >= subWave.whenToSpawn && !subWave.isInstanciated)
        //    {
        //        subWave.isInstanciated = true;
        //        //StartCoroutine(instanciateEnemies(subWave.enemy, subWave.amountOfEnemies, subWave.instanciateDelay));
        //        return true;

        //    }
        //    else return false;
        //}

        //private IEnumerator instanciateEnemies()
        //{
        //    amountOfEnemies = 10;
        //    //GameObject enemy, int amountOfEnemies, float instanciateDelay
        //    if (i < amountOfEnemies )
        //    {
        //        Instantiate(GameObject.FindGameObjectWithTag("enemy"), GameObject.FindGameObjectWithTag("enemy").transform.position, Quaternion.identity);
        //        yield return new WaitForSeconds(instanciateDelay);
        //        i++;
        //    }

        //}

        //private IEnumerator checkIfSubWavesAreReady() {

        //}

    }
    private void enemyInstantiate()
    {
        if (canSpawn)
        {
            if (i < amountOfEnemies)
            {
                if (timeCounter >= instanciateDelay/waveNumber)
                {   
                    enemyIndexer = UnityEngine.Random.Range(0, enemyPrefabs.Length);
                    //currentEnemies.Add();
                    Instantiate(enemyPrefabs[enemyIndexer], gameObject.transform.position, Quaternion.identity);
                    timeCounter = 0;
                    i++;


                }

            }
        }
            if (i >= amountOfEnemies)
            {
                canSpawn = false;

            if (GameObject.FindGameObjectsWithTag("enemy")==null )
            {
                timeCounter = 0;
            }
          
            if (timeCounter >= waveDelay)
            {
                
                waveNumber++;
                amountOfEnemies = amountOfEnemies + extraEnemies;
                canSpawn = true;

            }

        }
        }
    }


