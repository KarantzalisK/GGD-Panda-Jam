using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    //public GameObject arrow;
    private Transform closesPosition;
    public int towerDMG;
    private GameObject player,turretSpawner;
    public Vector3 firringDistanceOffset;
    private bool startCoroutine;
    public GameObject[] enemyArrays;
    public float reloadDelay,shootinSpeed,radius;
    private bool canShootBolts=false;
    public int enemyindex;
    public Vector2 towerEnemyDistance;
    public Collider2D enemyColiders;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(arrow);
        player = GameObject.FindGameObjectWithTag("Player");
        turretSpawner = GameObject.FindGameObjectWithTag("spawnpoint");
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
            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health + towerDMG;


        }
        if (collision.CompareTag("wall") || collision.CompareTag("externalBorder"))
        {
            StartCoroutine(destroyDelay());
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

        }
    }
    private IEnumerator destroyDelay()
    {
        player.GetComponent<PlayerScript>().canShoot = false;
        turretSpawner.GetComponent<TurretSpawnManager>().InstantianObject(this.gameObject);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);



    }
    private IEnumerator shootDelay(GameObject enemy)
    {
        Instantiate(GameObject.FindGameObjectWithTag("turretbolt"), this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(reloadDelay);
        GameObject.FindGameObjectWithTag("turretbolt").transform.position = Vector2.MoveTowards(GameObject.FindGameObjectWithTag("turretbolt").transform.position, enemy.transform.position, shootinSpeed*Time.deltaTime   );
        enemyindex++;

    }
}
