using UnityEngine;
using System.Collections;

public class WalkLeftCommand : Command
{
	public override void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		obj.transform.localScale = new Vector2 (-1, 1);	
		script.ForceX = -script.MaxSpeed;
	}
}
