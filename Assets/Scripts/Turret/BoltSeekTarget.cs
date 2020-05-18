using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSeekTarget : MonoBehaviour
{
    private Vector3 initialTurretPosition;
    private towerParameters tower;
    private TurretShooting turretShooting;
    private Vector3 targetToKill;
    // Start is called before the first frame update
    void Start()
    {
        tower= GameObject.FindObjectOfType<towerParameters>().GetComponent<towerParameters>();
        initialTurretPosition = tower.transform.position;
        turretShooting = tower.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForceAtPosition(targetToKill*tower.boltSpeed, targetToKill);    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        StartCoroutine(waitToDestroy());
        if (collision.CompareTag("enemy"))
        {
           collision.GetComponent<EnemyResetAndParameters>().health += collision.gameObject.GetComponentInParent<towerParameters>().boltdmg;
        }
       
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(tower.boltLifeSpam);
        Destroy(this.gameObject);
    }

}
