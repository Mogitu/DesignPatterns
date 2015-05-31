using UnityEngine;
using System.Collections;

public enum EnemyState
{
	EnemiesLeft,
	EnemyKilled,
	AllEnemiesKilled
}

public class EnemySubject : Subject
{
	//This one is for the inspector
	public EnemyState state = EnemyState.EnemiesLeft;

	//This one for getting and setting the state (setting a state will also call notify)
	public EnemyState enemyState
	{
		get { return state; }
		set 
		{
			if(state != value)
			{
				EnemyState oldState = state;
				state = value;
				notify();

				if(transform.childCount >= 0)
					state = oldState;
			}
		}
	}

}

