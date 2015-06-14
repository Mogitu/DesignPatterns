using UnityEngine;
using System.Collections;

public class JumpCommand : Command
{
	public void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
        if(script)
    		script.StartJump();
	}
}
