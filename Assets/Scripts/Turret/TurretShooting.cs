using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretShooting : MonoBehaviour

{   
    private towerParameters tower;
    private float smallestDistance;
    [HideInInspector]
    public Collider2D enemyToShoot;
    private List<GameObject> boltsAtHand;
    [HideInInspector]
    private float timer;
    [HideInInspector]
    public Collider2D[] currentEnemiesInScene;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<towerParameters>();
        smallestDistance = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
       



    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        FindClosestEnemy();
        if (timer >= tower.reloadDelay)
        {
            shoot();
            timer = 0;
        }

    }



    private void FindClosestEnemy()
    { 
        enemyToShoot = null;
       currentEnemiesInScene=(Physics2D.OverlapCircleAll(transform.position, tower.radius, tower.enemieLayer));
       
        foreach (Collider2D enemyIndex in currentEnemiesInScene)
        {
            float distance = (transform.position - enemyIndex.transform.position).sqrMagnitude;
           
                if (smallestDistance > distance)
                {
                    smallestDistance = distance;
                    enemyToShoot = enemyIndex;
                    Debug.DrawLine(this.transform.position, enemyIndex.transform.position);
                }
            
            if (enemyToShoot == null)
            {
                smallestDistance = Mathf.Infinity;
            }
        }

    }
    public void shoot()
    {

        Instantiate(tower.boltPrefab, tower.transform.position, Quaternion.identity);
    }
} 
