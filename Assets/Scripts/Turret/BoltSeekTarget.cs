using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSeekTarget : MonoBehaviour
{
    private towerParameters tower;
    private TurretShooting turretShooting;
    private Vector3 targetToKill;
    private Transform boltTransf;
    private float boltLifeSpam,boltdmg;
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        tower= GameObject.FindObjectOfType<towerParameters>().GetComponent<towerParameters>();
        turretShooting = tower.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        boltTransf = this.transform;
        boltLifeSpam = tower.boltLifeSpam;
        StartCoroutine(waitToDestroy());
        boltdmg = tower.boltdmg;

    }

    // Update is called once per frame
    void Update()
    {
        boltTransf.position = Vector2.MoveTowards(boltTransf.position,targetToKill,tower.boltSpeed*Time.deltaTime);
        //if (targetToKill == null)
        //{
        //    Destroy(this.gameObject);
        //}

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.CompareTag("enemy"))
        {
           collision.GetComponent<EnemyResetAndParameters>().health += boltdmg;
            Destroy(this.gameObject);
        }
        
        
       
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(boltLifeSpam);
        Destroy(this.gameObject);
    }

}
