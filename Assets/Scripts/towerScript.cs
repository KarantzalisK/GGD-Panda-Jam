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
    public float reloadDelay,shootinSpeed;
    private bool canShootBolts=false;
    private int enemyindex;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health + towerDMG;
            findEnemyDistanceNshoot();


        }
        if (collision.CompareTag("wall") || collision.CompareTag("externalBorder"))
        {
            StartCoroutine(destroyDelay());
        }

    }
    private void findEnemyDistanceNshoot()
    {
        {   if (firringDistanceOffset.x <= (this.gameObject.transform.position.x - enemyArrays[enemyindex].transform.position.x) & firringDistanceOffset.y <= (this.gameObject.transform.position.y - enemyArrays[enemyindex].transform.position.y)){

                StartCoroutine(shootDelay(enemyArrays[enemyindex]));
            }

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
