using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretShooting : MonoBehaviour

{
    private float radius;
    private towerParameters tower;
    public float smallestDistance;
    public EnemyResetAndParameters enemyToShoot;
    public List<GameObject> boltsAtHand;
    private bool canShoot;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<towerParameters>();
        smallestDistance = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
        EnemyResetAndParameters[] currentEnemiesInScene = GameObject.FindObjectsOfType<EnemyResetAndParameters>();
        foreach (EnemyResetAndParameters enemyIndex in currentEnemiesInScene)
        {
            float distance = (transform.position - enemyIndex.transform.position).sqrMagnitude;
            if (smallestDistance > distance &&distance<=tower.radius)
            {
                smallestDistance = distance;
                enemyToShoot = enemyIndex;
                Debug.DrawLine(this.transform.position, enemyIndex.transform.position);
            }
            if (enemyToShoot == null | (this.gameObject.transform.position-enemyToShoot.transform.position).sqrMagnitude>tower.radius)
            {
                smallestDistance = Mathf.Infinity;
            }
            Debug.LogWarning(distance);
        }

    }
    public void shoot()
    {

        Instantiate(tower.boltPrefab, tower.transform.position, Quaternion.identity);
    }
} 
