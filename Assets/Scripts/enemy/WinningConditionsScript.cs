using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WinningConditionsScript : MonoBehaviour
{
    private SpawnManager spawnManager;
    public GameObject winingPanel;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        WinIfMaxWaveReachedAndNoEnemiesInScene();
    }
    private void WinIfMaxWaveReachedAndNoEnemiesInScene()
    {
        if (spawnManager.waveNumber==spawnManager.activeWave.Count)//lastWaveISEmpty
        {
            winingPanel.SetActive(true);
        }
    }
}
