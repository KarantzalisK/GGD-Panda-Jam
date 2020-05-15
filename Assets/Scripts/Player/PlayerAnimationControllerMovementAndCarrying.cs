using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerMovementAndCarrying : MonoBehaviour
{
    private Vector2 movement;
    private Animator animatorComponent;
    private SpriteRenderer srOFobj;
    private bool holdingObject;


    // Start is called before the first frame update
    void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
        srOFobj = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        holdingObject = GetComponent<PlayerParameters>().holdingObject;
        movement = GetComponent<PlayerParameters>().movement;
        AnimationControl();

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
}
