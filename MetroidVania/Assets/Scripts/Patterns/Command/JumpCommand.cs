using UnityEngine;
using System.Collections;

public class JumpCommand : Command
{
	public override void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		if(script.grounded)
		{
			script.jump=true;
			script.Animator.SetBool("Jump",true);
		}
	}
}
