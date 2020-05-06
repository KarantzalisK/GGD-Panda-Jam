using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{
    //public GameObject arrow;
    private Transform closesPosition;
    public int towerDMG;
    private GameObject player,turretSpawner;
    private bool startCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(arrow);
        player = GameObject.FindGameObjectWithTag("Player");
        turretSpawner = GameObject.FindGameObjectWithTag("spawnpoint");
       
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

        }
        if (collision.CompareTag("wall") || collision.CompareTag("externalBorder"))
        {
            StartCoroutine(destroyDelay());
        }
    }
    private IEnumerator destroyDelay()
    {
        player.GetComponent<PlayerScript>().canShoot = false;
        turretSpawner.GetComponent<TurretSpawnManager>().InstantianObject(this.gameObject);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);



    }
}
