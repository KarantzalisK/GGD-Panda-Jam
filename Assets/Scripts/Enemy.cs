using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int pathIndex,waypointIndex;
    public float health,maxhealth;
    public float healthPercentage,healthspriteXWIDTH;
    public float speed;
    public EnemyPaths enemypath;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        pathIndex = Random.Range(0,1);
        enemypath= GameObject.FindGameObjectWithTag("spawnpoint").GetComponent<EnemyPaths>();

        transform.position = enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     if (health >= maxhealth)
        {
            Destroy(this.gameObject);
        }
        EnemyHealthBarMANAGER();
        enemyMovement();
    }

    
    private void EnemyHealthBarMANAGER()
    {
        healthPercentage = healthspriteXWIDTH - (health/maxhealth)*healthspriteXWIDTH;
        Debug.Log(healthPercentage + "healthpercentageEnemy");
        
    }
    public void enemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position,Time.deltaTime*speed);
        if (transform.position == enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
        }
        if (waypointIndex>= enemypath.enemyPaths[pathIndex].waypoints.Count) {
            Destroy(this.gameObject);
        }
    }

   
}
