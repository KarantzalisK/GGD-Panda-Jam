using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubWave
{
    public GameObject enemy;
    public int amountOfEnemies;
    public float whenToSpawn;
    public float instanciateDelay;

    [HideInInspector]
    public bool isInstanciated = false;


    public void subWaveReset()
    {
        isInstanciated = false;
    }


}

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public bool loopSpawning;
    public List<SubWave> subWaves;

    public void resetInstanciatedWave()
    {
        foreach (SubWave s in subWaves)
        {
            s.subWaveReset();
        }
    }

}

