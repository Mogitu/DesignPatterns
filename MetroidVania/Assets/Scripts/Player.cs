using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health=100;
	public float MaxSpeed=10;
	public float JumpForce=1000;
	private float forceX;

	//These objects can be seen as a part of the component structure
	private InputHandler inputHandler;
	private Rigidbody2D body;
	private Animator animator;
	private ShootBehaviour shootBehaviour;

	// Use this for initialization
	void Start () {
		//here we assign/cache the components.
		inputHandler = new InputHandler();
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		shootBehaviour = GetComponent<ShootBehaviour>();
	}

	void FixedUpdate(){
		/* at start of each physics frame we set several, physics related, values to 0 
           for when there is no input etc.
		 */		 
		forceX=0;
		Command command = inputHandler.HandleInput();
		//check if there is ANY type of command being executed.
		if(command!=null){
			command.Execute(gameObject);
		}
		animator.SetFloat("Speed",Mathf.Abs(forceX));
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

	public ShootBehaviour ShootBehaviour{
		get{return shootBehaviour;}
	}
}
