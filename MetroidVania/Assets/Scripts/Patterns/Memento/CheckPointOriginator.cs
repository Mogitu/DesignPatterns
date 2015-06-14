using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class CheckPointOriginator : MonoBehaviour {

	public CheckPointMemento CreateMemento()
	{
		return new CheckPointMemento(transform.position,transform.rotation,transform.localScale);
	}

	public void SetMemento(CheckPointMemento memento)
	{
		transform.position = memento.LastPosition;
		transform.rotation = memento.LastRotation;
		transform.localScale = memento.LastSize;
	}
}
