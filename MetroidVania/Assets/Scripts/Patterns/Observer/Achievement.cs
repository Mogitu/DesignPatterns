using UnityEngine;
using UnityEngine.UI;
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

		if(enState == EnemyState.EnemyKilled)
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
		Unlocked = true;
		// Show Achievement
		GameObject.Find("txtAchievement").GetComponent<SlideInText>().SlideIn(Name);
		
		enSubject.detach(this);
	}
}

