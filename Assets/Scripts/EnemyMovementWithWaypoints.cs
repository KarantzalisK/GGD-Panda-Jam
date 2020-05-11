using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWithWaypoints : MonoBehaviour
{
    private EnemyPaths enemyPathnWaypoints;
    [HideInInspector]
    public int pathIndex, waypointIndex;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        enemyPathnWaypoints = GameObject.FindGameObjectWithTag("spawnpoint").GetComponent<EnemyPaths>();
        transform.position = enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;
        speed = gameObject.GetComponent<EnemyResetAndParameters>().speed;
        waypointIndex = 0;
        pathIndex = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }
    public void enemyMovement()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position, Time.deltaTime * speed);
        if (this.gameObject.transform.position == enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
        }
        if (waypointIndex >= enemyPathnWaypoints.enemyPaths[pathIndex].waypoints.Count)
        {
            Destroy(this.gameObject);
        }
    }
}
