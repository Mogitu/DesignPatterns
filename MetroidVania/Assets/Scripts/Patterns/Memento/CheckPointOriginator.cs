using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class CheckPointOriginator : MonoBehaviour {

	public CheckPointMemento CreateMemento()
	{
		bool facingRight=true;
		if(gameObject.transform.localScale.x==-1)
		{
			facingRight=false;
		}
		return new CheckPointMemento(transform.position,transform.rotation,transform.localScale,facingRight);
	}

	public void SetMemento(CheckPointMemento memento)
	{
		transform.position = memento.LastPosition;
		transform.rotation = memento.LastRotation;
		transform.localScale = memento.LastSize;
		//gameObject.GetComponent<Player>().m_FacingRight = memento.FacingRight;
	}
}
