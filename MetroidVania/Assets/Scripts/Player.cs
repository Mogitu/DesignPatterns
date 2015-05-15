using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public InputHandler inputHandler;
	private float forceX;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		inputHandler = new InputHandler();
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		forceX=0;
		Command command = inputHandler.HandleInput();
		if(command!=null){
			command.Execute(gameObject);
		}
		body.velocity = new Vector2(forceX, body.velocity.y);
	}


	public float ForceX
	{
		get {return forceX;}
		set { forceX = value;}
	}
}
