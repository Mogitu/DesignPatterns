using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
abstract public class Subject : MonoBehaviour 
{
	public List<Observer> observers = new List<Observer>();

	public void Start()
	{
		for (int i = 0; i < observers.Count; i++)
			observers[i].setSubect(this);
	}


	public void attach(Observer ob)
	{
		observers.Add(ob);
	}

	public void detach(Observer ob)
	{
		observers.Remove(ob);
	}

	public void notify()
	{
		for (int i = 0; i < observers.Count; i++)
			observers[i].refresh();
	}

}
