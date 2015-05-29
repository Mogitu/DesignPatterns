using UnityEngine;
using System.Collections;
using Decorator;

[RequireComponent(typeof (Player))]
public class PowerUpBehaviour : MonoBehaviour 
{
	public enum PowerUpType
	{
		JUMPHIGHER,
		WALKFASTER,
		DOUBLEJUMP
	}
	public Decorator.Component controller;
	[HideInInspector]
	public Player character;
	// Use this for initialization
	void Start () 
	{
		controller = new PowerUpController(this);
		character = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		controller.DoOperation(this);
	}

	public void AddPowerUp(PowerUpType type,float duration)
	{

		switch(type)
		{
			case PowerUpType.JUMPHIGHER:
				controller = new JumpHigherPowerUp(this,controller,duration);
				break;
			case PowerUpType.WALKFASTER:
				controller = new WalkFasterPowerUp(this,controller,duration);
				break;
			default:break;
		}
	}
}
