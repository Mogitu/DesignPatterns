using UnityEngine;
using System.Collections;

abstract public class Achievement : Observer
{
	public string Name = "Place holder";
	public bool Unlocked = false;

	private EnemyState enState;
	private EnemySubject enSubject;

	public override void refresh ()
	{
		enState = enSubject.enemyState;

		if(enState == EnemyState.KILLED)
		{
			progress();
		}
	}

	public override void setSubect (Subject sub)
	{
		enSubject = (EnemySubject)sub;
	}

	abstract public void progress();

	public void unlock()
	{
		//Show Achievement
		print(Name);
	}
}

