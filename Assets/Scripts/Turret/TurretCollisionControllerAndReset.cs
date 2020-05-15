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
    private float towerdamage;
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
            collision.gameObject.GetComponent<EnemyResetAndParameters>().health = collision.gameObject.GetComponent<EnemyResetAndParameters>().health + GetComponent<towerParameters>().towerDMG;


        }
        if (collision.CompareTag("wall") )
        {
            player.canShoot = false;
        }
        if (collision.CompareTag("externalBorder"))
        {
            if (!player.carrying)
            {
                player.canShoot = false;
                returnTurret = true;
            }
        }
        if (collision.CompareTag("turretPlatform"))
        {

            returnTurret = false;
        }


    }

    private IEnumerator TurretRecover()
    {
        Vector2 objTransf;
        objTransf = transform.position;
        towerRespawnDelay = GetComponent<towerParameters>().turretRespawnDelay;
        yield return new WaitForSeconds(towerRespawnDelay);
        throwObj.shootingTurretAction(turretSpawningPosition);
    }
}
