using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesParameters : MonoBehaviour
{
    public int maxEnemies,amountOfFirstEnemyType;
    public int nextWaveStartDelay;
    public int numberOFenemyTypes;
    public float enemySpawningRate;
    [HideInInspector]
    public List<GameObject> currentEnemies;
    private GameObject spawnManager; 


// Start is called before the first frame update
void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count == maxEnemies)
        {
            StartCoroutine(waveChangeDelay());
        }
    }
    IEnumerator waveChangeDelay()
    {
        int existingEnemiesCounter=0;
        foreach (GameObject actvEnm in currentEnemies)
        {
            if (actvEnm== null)
            {
                existingEnemiesCounter++;
            }
        }
        if (existingEnemiesCounter >= maxEnemies)
        {
            currentEnemies.Clear();
            yield return new WaitForSeconds(nextWaveStartDelay);
            spawnManager.GetComponent<SpawnManager>().waveNumber++;
            spawnManager.GetComponent<SpawnManager>().canSpawn = true;
            spawnManager.GetComponent<SpawnManager>().i = 0;

            existingEnemiesCounter = 0;
        }
        }
}
