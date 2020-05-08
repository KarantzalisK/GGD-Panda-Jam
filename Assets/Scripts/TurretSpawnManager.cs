using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawnManager : MonoBehaviour
{
    private Rigidbody2D turretRb;
    public Vector3 SpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        turretRb = GameObject.FindGameObjectWithTag("turret").GetComponent<Rigidbody2D>();
        SpawnPoint = GameObject.FindGameObjectWithTag("turret").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantianObject(GameObject turret)
    {
        Instantiate(turret, SpawnPoint, Quaternion.identity);


    }
}
