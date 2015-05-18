using UnityEngine;
using System.Collections;

public class CheckPointCareTaker 
{

	private CheckPointMemento memento;

	public CheckPointMemento Memento
	{
		set{memento = value;}
		get{return memento;}
	}
}
