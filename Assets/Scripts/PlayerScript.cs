using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    public bool holdingObject = false;
    public Transform  newTurretPosition;
    private Transform turretTransf;
    private Animator animatorComponent;
    private SpriteRenderer srOFobj;
    private GameObject turret;
    public float throwingSpeed;
    private Rigidbody2D turretRb;
    public Vector2 onMouseclick;
    public bool canCarry = false, carrying = false,canShoot=false;


    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        srOFobj = gameObject.GetComponent<SpriteRenderer>();
        animatorComponent = gameObject.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        AnimationControl();
        PickUpTurret();
        FindInstantiatedTurret();
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        ShootinTurrets();


    }
    private void FindInstantiatedTurret()
    {   
        turret = GameObject.FindGameObjectWithTag("turret");
        if (turret.activeSelf==true){
            turretRb = turret.GetComponent<Rigidbody2D>();
            turretTransf = turret.transform;
        }
    }
    private void PickUpTurret()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && canCarry)
        {
            carrying = true;
            holdingObject = true;


        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKey(KeyCode.Mouse0))
        {
            carrying = false;
            holdingObject = false;


        }
        if (carrying)
        {
            turretTransf.position = newTurretPosition.position;


        }
        else
        {
            carrying = false;
            holdingObject = false;
        }
    }
    private void AnimationControl()
    {
        if (holdingObject)
        {
            animatorComponent.SetBool("HoldingOBJECTMovement", true);


        }
        if (!holdingObject)
        {
            animatorComponent.SetBool("HoldingOBJECTMovement", false);

        }

        if (movement.y > 0)
        {
            animatorComponent.SetBool("WalkingVertical", true);
            //srOFobj.flipY = true;

        }
        else if (movement.y < 0)
        {
            animatorComponent.SetBool("WalkingVertical", true);
            //srOFobj.flipY = false;
        }
        else
        {
            animatorComponent.SetBool("WalkingVertical", false);
        }

        if (movement.x > 0)
        {
            animatorComponent.SetBool("WalkingHorizontal", true);
            srOFobj.flipX = false;

        }
        else if (movement.x < 0)
        {
            animatorComponent.SetBool("WalkingHorizontal", true);
            srOFobj.flipX = true;
        }
        else
        {
            animatorComponent.SetBool("WalkingHorizontal", false);
        }
           



    }
    private void ShootinTurrets()
    {   if (Input.GetKey(KeyCode.Mouse0) && holdingObject)
        {
            onMouseclick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            canShoot = true;
            
        }
    if (canShoot)
        {
            turretRb.MovePosition(turretRb.position + onMouseclick * throwingSpeed * Time.fixedDeltaTime);
        }
        Debug.Log("eisai edw");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "turret")
        {
            canCarry = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "turret")
        {
            canCarry = false;
        }
    }

}
