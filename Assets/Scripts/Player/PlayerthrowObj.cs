using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerthrowObj : MonoBehaviour
{   //dependancyPlayerParameters and TurretCollisionController*
    // Start is called before the first frame update
    private Transform newTurretPosition;
    private Transform objTransf;
    private GameObject turret;
    private PlayerParameters player;
    private float throwingSpeed;
    [HideInInspector]
    public Vector3 clickVector;
    

    void Start()
    {
        player =this.gameObject.GetComponent<PlayerParameters>();
        turret = player.turretObj;
        objTransf = turret.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        throwingSpeed = player.throwingSpeed;
        Debug.Log(Input.mousePosition);

    }
    void FixedUpdate()
    {
        ShootinTurretsController();

    }
    public void ShootinTurretsController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& player.carrying&& player.holdingObject)
        {
            clickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        turret.transform.position = Vector2.MoveTowards(turret.transform.position, genreicVector, throwingSpeed * Time.fixedDeltaTime);
    }
}
