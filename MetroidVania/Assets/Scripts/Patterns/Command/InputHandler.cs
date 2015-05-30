using UnityEngine;
using System.Collections;

public class InputHandler  {
	public JumpCommand jump;
	public WalkLeftCommand WalkLeft;
	public WalkRightCommand walkRight;
	public ShootCommand shoot;


	public InputHandler()
	{
		jump = new JumpCommand();
		WalkLeft = new WalkLeftCommand();
		walkRight = new WalkRightCommand();
		shoot = new ShootCommand();
	}

	public Command HandleInput()
	{
		if(Input.GetKeyDown(KeyCode.Space))return jump;
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))return WalkLeft;
		if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))return walkRight;
		if(Input.GetKey(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))return shoot;
		return null;
	}
}
