using UnityEngine;
using System.Collections;
using Decorator;
using UnityStandardAssets._2D;
[RequireComponent(typeof (PlatformerCharacter2D))]
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
	public PlatformerCharacter2D character;
	// Use this for initialization
	void Start () 
	{
		controller = new PowerUpController(this);
		character = GetComponent<PlatformerCharacter2D>();
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
