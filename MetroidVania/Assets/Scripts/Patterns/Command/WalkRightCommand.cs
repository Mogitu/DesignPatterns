using UnityEngine;
using System.Collections;

public class WalkRightCommand : Command
{
	public void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
        if (script)
		    script.Walk(script.MaxSpeed);
	}
}
