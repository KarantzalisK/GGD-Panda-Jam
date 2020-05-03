using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemyPaths> enemyPaths;

    [SerializeField]
    public List<Wave> Waves;

    public float timeCounter;

    void Start()
    {

    }

    void Update()
    {
        timeCounter += Time.deltaTime;
    }

    private bool subWaveInstanciation(SubWave subWave)
    {
        if (timeCounter >= subWave.whenToSpawn && !subWave.isInstanciated)
        {
            subWave.isInstanciated = true;
            StartCoroutine(instanciateEnemies(subWave.enemy, subWave.amountOfEnemies, subWave.instanciateDelay));
            return true;

        }
    }

    private IEnumerator instanciateEnemies(GameObject enemy, int amountOfEnemies, float instanciateDelay)
    {

        for (int i = 0; i < amountOfEnemies; i++)
        {
            yield return new WaitForSeconds(instanciateDelay);
        }
    }

    private IEnumerator checkIfSubWavesAreReady() { 
        
        
    }

}

