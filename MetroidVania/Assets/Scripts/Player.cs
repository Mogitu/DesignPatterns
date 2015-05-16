using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health=100;
	public float walkSpeed=2;
	public float jumpPower=300;
	private float forceX;

	//These objects can be seen as a part of the component structure
	private InputHandler inputHandler;
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Start () {
		//here we assign/cache the components.
		inputHandler = new InputHandler();
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){
		/* at start of each physics frame we set several, physics related, values to 0 
           for when there is no input etc.
		 */		 
		forceX=0;
		animator.SetBool("walking",false);
		Command command = inputHandler.HandleInput();
		//check if there is ANY type of command being executed.
		if(command!=null){
			command.Execute(gameObject);
		}
		//we update the speed depending on values we get from the input
		body.velocity = new Vector2(forceX, body.velocity.y);
	}
	
	// Update is called once per frame
	void Update () {

	}


	public float ForceX
	{
		get {return forceX;}
		set { forceX = value;}
	}

	public Animator Animator{
		get {return animator;}
	}
}
