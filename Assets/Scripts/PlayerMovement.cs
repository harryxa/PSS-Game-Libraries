using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed = 1.0f;
    public float max_force = 20f;
    public Vector2 moveDirection = Vector2.zero;
    public float jump_height = 1.0f;
    public float gravity = 50.0f;
    public float jump_force = 50.0f;
    public Vector2 impulse_force = Vector2.zero;
	public AudioSource jump;

    private bool knockedOutRef;

    private bool grounded = false;
	private string axis_string = "";
	private string jump_string = "";
	private string player_name = "";

    /*.................................................
      IMPULSE BASED X,Y MOVEMENT
      (works much better using gamepad)
      .................................................
    */


    void Start()
    {
        //Initialisations
        rig = GetComponent<Rigidbody2D>();
        rig.mass = 5.0f;
        rig.drag = 5.0f;
        rig.freezeRotation = true;
        rig.gravityScale = 0.0f;

		if (gameObject.tag == "Player")
        {
			axis_string = "Horizontal";
			jump_string = "Jump";
			player_name = "Player";
		}
		if (gameObject.tag == "Player2")
        {
			axis_string = "Horizontal2";
			jump_string = "P2 Jump";
			player_name = "Player2";
		}
		if (gameObject.tag == "Player3")
        {
			axis_string = "Horizontal3";
			jump_string = "P3 Jump";
			player_name = "Player3";
		}
		if (gameObject.tag == "Player4")
        {
			axis_string = "Horizontal4";
			jump_string = "P4 Jump";
			player_name = "Player4";
		}

    }


    //Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == player_name && knockedOutRef == false)
        {
            moveDirection.x = (Input.GetAxis(axis_string));
            if (moveDirection.x < 0.1 && moveDirection.x > -0.1)
            {
                moveDirection.x = 0;
            }
            impulse_force = Vector2.ClampMagnitude((speed * moveDirection * rig.mass), max_force);

            if (grounded)
            {
				if(Input.GetButton(jump_string)  )
                {
                    rig.AddForce(new Vector2(0, jump_force * rig.mass));
					jump.Play ();
                }
                
            }
        }
        if (!grounded)
        {
            moveDirection.y = 0;
        }

        rig.AddForce(new Vector2(0, -gravity * rig.mass));
        rig.AddForce(impulse_force, ForceMode2D.Impulse);
        moveDirection = Vector2.zero;
        impulse_force = Vector2.zero;
    }



    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            grounded = true;
        }

    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            transform.parent = col.gameObject.transform;
        }
    }

    //Not working, but could be?
    //public bool isGrounded()
    //{
    //    return Physics.Raycast(rig.transform.position, -Vector2.up, dist_to_ground);
    //}

}