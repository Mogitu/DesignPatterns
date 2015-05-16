﻿using UnityEngine;
using System.Collections;

public class WalkRightCommand : Command
{
	public override void Execute (GameObject obj)
	{
		Player script = obj.GetComponent<Player> ();
		obj.transform.localScale = new Vector2 (1, 1);
		script.Animator.SetBool("walking",true);
		script.ForceX = script.walkSpeed;
	}
}
