using UnityEngine;
using System.Collections;

public class CheckPointMemento {


	private Vector3 lastPosition;
	private Quaternion lastRotation;
	private Vector3 lastSize;
	public CheckPointMemento(Vector3 lastPosition, Quaternion lastRotation, Vector3 lastSize)
	{
		this.lastPosition = lastPosition;
		this.lastRotation = lastRotation;
		this.lastSize = lastSize;
	}

	public Vector3 LastPosition
	{
		get{return lastPosition;}
	}
	
	public Quaternion LastRotation
	{
		get{return lastRotation;}
	}
	public Vector3 LastSize
	{
		get{return lastSize;}
	}
}
