using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int pathIndex,waypointIndex;
    public float health,maxhealth;
    public float healthPercentage,healthspriteXWIDTH, initialhealthspriteXWIDTH, initialhealthPercentage,initialhealth;
    public float speed;
    private Vector2 startinPosition;
    public EnemyPaths enemypath;
    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        pathIndex = Random.Range(0,4);
        enemypath= GameObject.FindGameObjectWithTag("spawnpoint").GetComponent<EnemyPaths>();

        transform.position = enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;
        startinPosition = transform.position;
        initialhealth = health;
        
    }

    // Update is called once per frame
    void Update()
    {
     if (health >= maxhealth)
        {
            //Destroy(this.gameObject);
            resetStats();
            

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
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position,Time.deltaTime*speed);
        if (this.gameObject.transform.position == enemypath.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
        }
        if (waypointIndex>= enemypath.enemyPaths[pathIndex].waypoints.Count) {
            resetStats();
            waypointIndex = 0;
        }
    }
    public void resetStats() 
    {
        transform.position = startinPosition;
        health = initialhealth;
        healthPercentage = initialhealthPercentage;
        healthspriteXWIDTH = initialhealthspriteXWIDTH;
        gameObject.GetComponentInChildren<enemyHealthBarManager>().localScaleATruntime.x= initialhealthspriteXWIDTH;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("turretbolt"))
        {
            health=health+collision.gameObject.GetComponentInParent<towerScript>().towerDMG/3;
        }
    }


}
