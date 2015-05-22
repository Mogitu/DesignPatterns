using UnityEngine;
using System.Collections;

public enum EnemyState
{
	ALIVE,
	KILLED
}

public class EnemySubject : Subject
{
	//This one is for the inspector
	public EnemyState state = EnemyState.ALIVE;

	//This one for getting and setting the state (setting a state will also call notify)
	public EnemyState enemyState
	{
		get { return state; }
		set 
		{
			if(state != value)
			{
				state = value;
				notify();
			}
		}
	}

}

