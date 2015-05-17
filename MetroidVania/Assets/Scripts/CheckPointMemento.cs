using UnityEngine;
using System.Collections;

public class CheckPointMemento {


	private Vector3 lastPosition;
	private Quaternion lastRotation;
	private Vector3 lastSize;
	private bool facingRight;
	public CheckPointMemento(Vector3 lastPosition, Quaternion lastRotation, Vector3 lastSize,bool facingRight)
	{
		this.lastPosition = lastPosition;
		this.lastRotation = lastRotation;
		this.lastSize = lastSize;
		this.facingRight = facingRight;
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
	public bool FacingRight
	{
		get{return facingRight;}
	}
}
