using UnityEngine;
/**
 * Author: Maikel van Munsteren
 * Desc:   Figure out which key was pressed and invoke a (new) command.
 * Todo:   To avoid massive command creation, we can/should instead declare the needed commands and init them in the constructor.
 *         For testing/demonstrating new commands, the current setup works quickly.
 * */
public class InputHandler  {
	
	public Command HandleInput()
	{
		if(Input.GetKey(KeyCode.Space))return new JumpCommand();
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))return new WalkLeftCommand();
		if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))return new WalkRightCommand();
		if(Input.GetKey(KeyCode.LeftControl) || Input.GetButton("Fire1"))return new ShootCommand();
		return null;
	}
}
