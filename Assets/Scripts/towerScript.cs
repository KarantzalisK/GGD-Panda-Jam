using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerScript : MonoBehaviour
{ public GameObject arrow,towerPrefab;
    private Transform closesPosition;
    public int towerDMG;
    public Vector3 SpawnPoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arrow);
        SpawnPoint = GameObject.FindGameObjectWithTag("spawnpoint").transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health= collision.gameObject.GetComponent<Enemy>().health+towerDMG;
            player.GetComponent<PlayerScript>().canShoot = false;

        }
        if (collision.tag=="wall" | collision.tag == "externalBorder")
        {
            Instantiate(towerPrefab, SpawnPoint, Quaternion.identity);
            Destroy(this.gameObject);
           

        }
    }
   
}
