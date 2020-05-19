using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSeekTarget : MonoBehaviour
{
    private Vector3 initialTurretPosition;
    private towerParameters tower;
    private TurretShooting turretShooting;
    private Vector3 targetToKill;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        tower= GameObject.FindObjectOfType<towerParameters>().GetComponent<towerParameters>();
        initialTurretPosition = tower.transform.position;
        turretShooting = tower.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(targetToKill * tower.boltSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        StartCoroutine(waitToDestroy());
        if (collision.CompareTag("enemy"))
        {
           collision.GetComponent<EnemyResetAndParameters>().health +=tower.boltdmg;
        }
        
        
       
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(tower.boltLifeSpam);
        Destroy(this.gameObject);
    }

}
