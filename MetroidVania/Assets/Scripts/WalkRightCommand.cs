using UnityEngine;
using System.Collections;

public class WalkRightCommand : Command {

	public override void Execute(GameObject obj)
	{
		Player script = obj.GetComponent<Player>();
		script.ForceX =2;
	}
}
