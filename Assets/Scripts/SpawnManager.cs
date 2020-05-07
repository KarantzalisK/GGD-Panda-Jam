﻿using System.Collections;
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
    public bool canSpawn = true;
    public int i = 0, amountOfEnemies, enemyIndexer, waveNumber = 1, extraEnemies;
    public GameObject[] enemyPrefabs;


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
                    Instantiate(enemyPrefabs[enemyIndexer], gameObject.transform.position, Quaternion.identity);

                    timeCounter = 0;
                    i++;


                }

            }
        }
            if (i >= amountOfEnemies)
            {
                canSpawn = false;

                if (timeCounter >= waveDelay)
                {
                    i = 0;
                    waveNumber++;
                    amountOfEnemies =amountOfEnemies+extraEnemies;
                    canSpawn = true;
                
                }




            }
        }
    }


