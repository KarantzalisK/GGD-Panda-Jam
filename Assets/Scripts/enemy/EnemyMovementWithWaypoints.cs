using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWithWaypoints : MonoBehaviour
{
    private EnemyPaths enemyPathnWaypoints;
    [HideInInspector]
    public int pathIndex, waypointIndex;
    private SpawnManager spawnMng;
    private EnemyResetAndParameters enemyStats;
    private GameObject spawnobj;
    private Vector3 enemyObjectivePos;


    // Start is called before the first frame update
    void Start()
    {
        spawnobj = GameObject.FindGameObjectWithTag("spawnpoint");
        enemyPathnWaypoints = spawnobj.GetComponent<EnemyPaths>();
        enemyStats = gameObject.GetComponent<EnemyResetAndParameters>();
        pathIndex = Random.Range(0, spawnobj.GetComponent<SpawnManager>().enemyPaths.Count+1);
        waypointIndex = 0;
        transform.position = enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }
    public void enemyMovement()
    {
        enemyObjectivePos = enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, enemyObjectivePos, enemyStats.speed* Time.deltaTime);
        if (this.gameObject.transform.position == enemyObjectivePos)
        {
            waypointIndex++;
        }
        if (waypointIndex >= enemyPathnWaypoints.enemyPaths[pathIndex].waypoints.Count)
        {
            Destroy(this.gameObject);
        }
    }
 
}
