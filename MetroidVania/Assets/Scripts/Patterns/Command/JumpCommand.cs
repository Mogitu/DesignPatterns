using UnityEngine;
using System.Collections;

public class JumpCommand : Command
{
	public override void Execute (GameObject obj)
	{
		Rigidbody2D body = obj.GetComponent<Rigidbody2D> ();
		Player script = obj.GetComponent<Player> ();
		//can only jump when we the player isnt currently falling or jumping.
		if (Mathf.Abs (body.velocity.y) <= 0.01) {
			body.AddForce (Vector2.up * script.JumpForce);
		}
	}
}
