using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public KeyCode up, down, left, right, runButton;
    public float speed, jump, runSpeed;
    private bool onMove = true;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, speed);
            onMove = false;

        }
        if (Input.GetKey(down))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, -speed);
        }
        if (Input.GetKey(right))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(left))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyDown(right) && Input.GetKeyDown(runButton))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(left) && Input.GetKey(runButton))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * runSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(up))
            if (Input.GetKey(right) && Input.GetKey(runButton))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * runSpeed, runSpeed*runSpeed);
            }
        if (Input.GetKeyUp(up))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
        }
        if (Input.GetKeyUp(down))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0.0f);
        }
        if (Input.GetKeyUp(right))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(left))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(right) && Input.GetKeyUp(runButton))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(left) && Input.GetKeyUp(runButton))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(up)|| Input.GetKey(down))
        {
            gameObject.GetComponent<Animator>().SetBool("WalkingVertical", true);
        }
        else gameObject.GetComponent<Animator>().SetBool("WalkingVertical", false);

        if (Input.GetKey(left) || Input.GetKey(right))
        {
            gameObject.GetComponent<Animator>().SetBool("WalkingHorizontal", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("WalkingHorizontal", false);
        }
    }
}