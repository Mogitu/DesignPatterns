using UnityEngine;
using System.Collections;

public class KillAchievement : Achievement
{
	public int killTargetCount = 1;
	private int killCount = 0;


	public override void progress ()
	{
		killCount++;

		if(killCount >= killTargetCount)
			unlock();
	}
}

