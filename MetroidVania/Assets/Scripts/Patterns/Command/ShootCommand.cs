using UnityEngine;
using System.Collections;

public class ShootCommand : Command
{
	public void Execute (GameObject obj)
	{
		ShootBehaviour script = obj.GetComponent<ShootBehaviour> ();
        if(script)
		    script.Shoot();
	}
}
