using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSeekTarget : MonoBehaviour
{
    private towerParameters tower;
    private TurretShooting turretShooting;
    private Vector3 targetToKill;
    private Transform boltTransf;
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        tower= GameObject.FindObjectOfType<towerParameters>().GetComponent<towerParameters>();
        turretShooting = tower.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        boltTransf = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        boltTransf.position = Vector2.MoveTowards(boltTransf.position,targetToKill,tower.boltSpeed*Time.deltaTime);

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
