using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerResetPositionConditioner : MonoBehaviour
{
    public Vector2 targetPosition,turretCurrentPosition,initialPosition;
    private PlayerParameters playerParameters;
    private TurretCollisionControllerAndReset turretCollisionNReset;
    private towerParameters towerParameters;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        playerParameters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameters>();
        turretCollisionNReset = GetComponent<TurretCollisionControllerAndReset>();
        towerParameters = GetComponent<towerParameters>();
    }

    // Update is called once per frame
    void Update()
    {
        TurretResetConditions();
    }
    private void TurretResetConditions()
    {
        turretCurrentPosition = transform.position;
        targetPosition = playerParameters.clickVector;

        if (Vector2.Distance(turretCurrentPosition,targetPosition)<=towerParameters.towerReturnDistanceOffset)
        {
            turretCollisionNReset.returnTurret = true;
            playerParameters.canShoot = false;
        }
        else if (Vector2.Distance(initialPosition, turretCurrentPosition) <= towerParameters.towerReturnDistanceOffset)
        {
            turretCollisionNReset.returnTurret = false;
        }

        //Debug.LogWarning("distance: " + Vector2.Distance(turretCurrentPosition, targetPosition) + "towerReturnDistanceOffset: " + towerParameters.towerReturnDistanceOffset);
        //Debug.Log(turretCollisionNReset.returnTurret+"return TurretBOOlean");
        //Debug.DrawLine(initialPosition, targetPosition);
    }
}
