using UnityEngine;
using UnityEngine.UI;
using System.Collections;

abstract public class Achievement : Observer
{
	public string Name = "Place holder";
	public bool Unlocked = false;

	private EnemyState enState;
	private EnemySubject enSubject;

	void Start()
	{

	}

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
		// TODO: Not need anymore?
		Unlocked = true;

		// Show Achievement
		GameObject.Find("txtAchievement").GetComponent<SlideInText>().SlideIn(Name);

		// Detach because we don't have to update the achievement anymore
		enSubject.detach(this);
	}
}

