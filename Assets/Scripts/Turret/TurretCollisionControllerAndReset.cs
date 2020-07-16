using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollisionControllerAndReset : MonoBehaviour
{
    private PlayerParameters player;
    private PlayerthrowObj throwObj;
    [HideInInspector]
    public Vector2 turretSpawningPosition;
    private float towerRespawnDelay;
    [HideInInspector]
    public bool returnTurret=false;
    private GameObject playerOBJ;

    // Start is called before the first frame update
    void Start()
    {
        playerOBJ = GameObject.FindGameObjectWithTag("Player");
        player =playerOBJ.GetComponent<PlayerParameters>();
        throwObj = playerOBJ.GetComponent<PlayerthrowObj>();
        turretSpawningPosition = this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {if (returnTurret)
        {
            
                StartCoroutine(TurretRecover());
            }
        else         {
            StopAllCoroutines();
        }

       


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<EnemyResetAndParameters>().health +=  GetComponent<towerParameters>().towerDMG;


        }
        if (collision.CompareTag("wall") )
        {
            player.canShoot = false;
        }
      

    }
    private IEnumerator TurretRecover()
    {
        
        towerRespawnDelay = GetComponent<towerParameters>().turretRespawnDelay;
        yield return new WaitForSeconds(towerRespawnDelay);
        throwObj.shootingTurretAction(turretSpawningPosition);
    }
    
}
