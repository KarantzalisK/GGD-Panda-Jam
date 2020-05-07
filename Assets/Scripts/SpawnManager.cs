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
        else return false;
    }

    private IEnumerator instanciateEnemies(GameObject enemy, int amountOfEnemies, float instanciateDelay)
    {

        for (int i = 0; i < amountOfEnemies;)
        {
            Instantiate(GameObject.FindGameObjectWithTag("enemy"), GameObject.FindGameObjectWithTag("enemy").transform.position, Quaternion.identity);
            yield return new WaitForSeconds(instanciateDelay);
            i++;
        }
    }

    //private IEnumerator checkIfSubWavesAreReady() {

    //}

}

