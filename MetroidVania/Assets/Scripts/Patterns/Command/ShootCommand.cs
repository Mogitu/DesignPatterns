using UnityEngine;
using System.Collections;

public class ShootCommand : Command
{
	public void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		script.ShootBehaviour.Shoot();

	}
}
