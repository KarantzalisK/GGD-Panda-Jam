using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerMovementAndCarrying : MonoBehaviour
{
    private Animator animatorComponent;
    private SpriteRenderer srOFobj;
    private PlayerParameters playerStats;


    // Start is called before the first frame update
    void Start()
    {
        animatorComponent = GetComponent<Animator>();
        srOFobj = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerParameters>();

    }

    // Update is called once per frame
    //this is in update
    void Update()
    {
        AnimationControl();

    }
    private void AnimationControl()
    {
        if (playerStats.holdingObject)
        {
            animatorComponent.SetBool("HoldingOBJECTMovement", true);


        }
        if (!playerStats.holdingObject)
        {
            animatorComponent.SetBool("HoldingOBJECTMovement", false);

        }

        if (playerStats.movement.y > 0)
        {
            animatorComponent.SetBool("WalkingVertical", true);
            //srOFobj.flipY = true;

        }
        else if (playerStats.movement.y < 0)
        {
            animatorComponent.SetBool("WalkingVertical", true);
            //srOFobj.flipY = false;
        }
        else
        {
            animatorComponent.SetBool("WalkingVertical", false);
        }

        if (playerStats.movement.x > 0)
        {
            animatorComponent.SetBool("WalkingHorizontal", true);
            srOFobj.flipX = false;

        }
        else if (playerStats.movement.x < 0)
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
