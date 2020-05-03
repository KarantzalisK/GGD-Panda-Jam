using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 movement;
    public float speed;
    public bool holdingObject = false;
    public Transform turretTransf, newTurretPosition;
    private Animator animatorComponent;
    private SpriteRenderer srOFobj;
    public bool canCarry = false, carrying = false;


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

    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }
    private void PickUpTurret()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCarry)
        {
            carrying = true;
            holdingObject = true;


        }
        if (Input.GetKeyUp(KeyCode.E))
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
            srOFobj.flipY = true;

        }
        else if (movement.y < 0)
        {
            animatorComponent.SetBool("WalkingVertical", true);
            srOFobj.flipY = false;
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
        if (carrying)
        {

        }



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
