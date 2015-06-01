using UnityEngine;
using System.Collections;

public class WalkLeftCommand : Command
{
	public void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		script.Walk(-script.MaxSpeed);
	}
}
