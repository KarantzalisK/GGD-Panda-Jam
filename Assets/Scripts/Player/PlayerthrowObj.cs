using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerthrowObj : MonoBehaviour
{   //dependancyPlayerParameters and TurretCollisionController*
    // Start is called before the first frame update
    private GameObject turret;
    private PlayerParameters player;
    [HideInInspector]
    public Vector3 clickVector;
    

    void Start()
    {
        player =this.gameObject.GetComponent<PlayerParameters>();
        turret = player.turretObj;
    }

    // Update is called once per frame
    void Update()
    { 
        
        ShootinTurretsController();

    }


    public void ShootinTurretsController()
    {   //canshoot is used in order to stop the MoveTowards at set Moments without waiting to reach the exact coordinates since that is verry time consuming and game breaking
        if (Input.GetKeyDown(KeyCode.Mouse0)&&player.carrying)
        {
            clickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.clickVector = clickVector;
            player.carrying = false;
            player.holdingObject = false;
            player.canShoot = true;
           
        }
       if (player.canShoot)
        {
            shootingTurretAction(clickVector);
        }
          
            
        




    }
    public void shootingTurretAction(Vector2 genreicVector)
    {   
        turret.transform.position = Vector2.MoveTowards(turret.transform.position, genreicVector, player.throwingSpeed * Time.deltaTime);
    }
}
