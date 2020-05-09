using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    //public GameObject arrow;
    private Transform closesPosition;
    public int towerDMG;
    public float towerRespawnDelay;
    private GameObject player;
    public Vector3 firringDistanceOffset;
    private bool startCoroutine;
    public GameObject[] enemyArrays;
    public float reloadDelay,shootinSpeed,radius;
    private bool canShootBolts=false;
    public int enemyindex;
    public Vector2 towerEnemyDistance,turretSpawningPosition;
    public Collider2D enemyColiders;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(arrow);
        player = GameObject.FindGameObjectWithTag("Player");
        turretSpawningPosition = this.gameObject.transform.position;
        enemyArrays = GameObject.FindGameObjectsWithTag("enemy");
        enemyindex = 0;


    }

    // Update is called once per frame
    void Update()
    {
        findEnemyDistanceNshoot();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyResetAndParameters>().health = collision.gameObject.GetComponent<EnemyResetAndParameters>().health + towerDMG;


        }
        if (collision.CompareTag("wall") || collision.CompareTag("externalBorder"))
        {
            player.GetComponent<PlayerScript>().canShoot = false;
            StartCoroutine(turretRespawnWithDelay());
        }

    }
    private void findEnemyDistanceNshoot()
    {
        //towerEnemyDistance = this.gameObject.transform.position-enemyArrays[enemyindex].transform.position;
        //{    if (enemyArrays[enemyindex] == null )
        //    {
        //        enemyindex++;
        //    }
        //    else if (firringDistanceOffset.x <= (Mathf.Abs(towerEnemyDistance.x)) && firringDistanceOffset.y <= Mathf.Abs(towerEnemyDistance.y))
        //    {

        //        StartCoroutine(shootDelay(enemyArrays[enemyindex]));
        //    }

        //}
        //if (enemyindex>=enemyArrays.Length)
        //{
        //    enemyindex = 0;

        //}
        enemyColiders= Physics2D.OverlapCircle(gameObject.transform.position, radius);
         if (enemyColiders.CompareTag("enemy"))
        {
            GameObject.FindGameObjectWithTag("turretbolt").transform.position = Vector2.MoveTowards(GameObject.FindGameObjectWithTag("turretbolt").transform.position, enemyColiders.gameObject.transform.position, shootinSpeed * Time.deltaTime);
            StartCoroutine(shootDelay(enemyColiders.gameObject));
        }
    }
 
    private IEnumerator turretRespawnWithDelay( )
    {
        yield return new WaitForSeconds(towerRespawnDelay);
        gameObject.transform.position = turretSpawningPosition;

    }
    private IEnumerator shootDelay(GameObject enemy)
    {
        Instantiate(GameObject.FindGameObjectWithTag("turretbolt"), this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(reloadDelay);
        GameObject.FindGameObjectWithTag("turretbolt").transform.position = Vector2.MoveTowards(GameObject.FindGameObjectWithTag("turretbolt").transform.position, enemy.transform.position, shootinSpeed*Time.deltaTime   );
        enemyindex++;

    }
}
