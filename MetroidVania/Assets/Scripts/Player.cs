using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float MaxSpeed=10;
	public float jumpForce=1000;
	
	private float forceX;
	private bool jump=false;
	private bool grounded=true;

	//Attached objects
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Start () {
		//here we assign/cache the components.	
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){	
		//check if player is touching the groun
		if(Mathf.Abs(body.velocity.y)<=0.01f){
			grounded=true;
		}else{
			grounded=false;
		}
		//we update the speed depending on values we get from the input
		body.velocity = new Vector2(forceX, body.velocity.y);

		//update the animator
		animator.SetFloat("Speed",Mathf.Abs(forceX));
		animator.SetBool("Ground", grounded);
		animator.SetBool("Jump",jump);
		forceX=0;	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//set up the animator for jumping
	public void StartJump()
	{
		if(grounded)
		{
			jump=true;
			animator.SetBool("Jump",true);
		}
	}

	//make the real jump(executed at a specific frame in the animator)
	public void Jump()
	{
		// Add a vertical force to the player.
		grounded = false;	
		jump=false;
		animator.SetBool("Ground", false);
		animator.SetBool("Jump", false);
		body.AddForce(new Vector2(0f, jumpForce));
	}

	public void Walk(float speed)
	{
		//make sprite face correct direction
		if(speed < 0){
			transform.localScale = new Vector2 (-1, 1);	
		}else{
			transform.localScale = new Vector2 (1, 1);	
		}	
		forceX = speed;
	}

}
