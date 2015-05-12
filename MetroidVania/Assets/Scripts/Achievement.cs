using UnityEngine;
using System.Collections;

public class Achievement : MonoBehaviour, IObserver {
	public bool unlocked 	= false;
	public string name 		= "";
	public float showTimer 	= 3;
	public int speed 		= 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(unlocked)
		{
			//Show Achievement
		}
	}

	public void notify()
	{
		unlock();
	}

	void unlock()
	{
		unlocked = true;
	}

}
