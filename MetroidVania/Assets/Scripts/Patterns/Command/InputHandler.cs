using UnityEngine;
using System.Collections;

public class InputHandler  {
	public JumpCommand jump;
	public WalkLeftCommand WalkLeft;
	public WalkRightCommand walkRight;


	public InputHandler()
	{
		jump = new JumpCommand();
		WalkLeft = new WalkLeftCommand();
		walkRight = new WalkRightCommand();
	}

	public Command HandleInput()
	{
		if(Input.GetKey(KeyCode.Space))return jump;
		if(Input.GetKey(KeyCode.LeftArrow))return WalkLeft;
		if(Input.GetKey(KeyCode.RightArrow))return walkRight;
		return null;
	}
}
