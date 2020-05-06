using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class waypointList
{
    public List<GameObject> waypoints;
}

[CreateAssetMenu(fileName = "New Enemy Paths", menuName = "Enemy Paths")]
public class EnemyPaths : MonoBehaviour
{
    public List<waypointList> enemyPaths;
    private bool canSpawn = false;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            StartCoroutine(spawnDelay());
        }
    }
    IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(GameObject.FindGameObjectWithTag("enemy"), GameObject.FindGameObjectWithTag("enemy").transform.position, Quaternion.identity);

    }
}
