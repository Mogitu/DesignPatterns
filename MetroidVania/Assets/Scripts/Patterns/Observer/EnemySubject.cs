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
	// State is visible in inspector
	public EnemyState state = EnemyState.EnemiesLeft;

	// Set function also calls notify()
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

				if(transform.childCount > 0)
					state = oldState;
			}
		}
	}
}

