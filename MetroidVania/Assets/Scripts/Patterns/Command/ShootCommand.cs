using UnityEngine;
using System.Collections;

public class ShootCommand : Command
{
	public override void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		script.ShootBehaviour.Shoot();

	}
}
