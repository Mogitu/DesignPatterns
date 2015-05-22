using UnityEngine;
using UnityEngine.UI;
using System.Collections;

abstract public class Achievement : Observer
{
	public string Name = "Place holder";
	public bool Unlocked = false;

	private EnemyState enState;
	private EnemySubject enSubject;
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

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
		text.enabled = true;
		GetComponent<SlideInText>().enabled = true;
		text.text = Name;

	}
}

