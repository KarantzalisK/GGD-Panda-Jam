using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    [HideInInspector]
    public bool canCarry = false, carrying = false, canShoot = false;
    [HideInInspector]
    public bool holdingObject = false;
    public float throwingSpeed;
    [HideInInspector]
    public Vector2 movement;
    public Transform newTurretPosition;
    [HideInInspector]
    public GameObject turretObj;
    [HideInInspector]
    public Vector2 clickVector;





    // Start is called before the first frame update
    void Start()
    {
        turretObj = GameObject.FindGameObjectWithTag("turret");



    }

    // Update is called once per frame
    void Update()
    {
        movement = GetComponent<PlayerMovement>().movement;
        clickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }











}
