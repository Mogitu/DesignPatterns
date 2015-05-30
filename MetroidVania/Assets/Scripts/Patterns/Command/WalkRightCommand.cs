using UnityEngine;
using System.Collections;

public class WalkRightCommand : Command
{
	public void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		obj.transform.localScale = new Vector2 (1, 1);
		script.ForceX = script.MaxSpeed;
	}
}
