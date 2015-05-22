using UnityEngine;
using System.Collections;

namespace Decorator
{
	public class PowerUpController : Component 
	{
		PowerUpBehaviour behaviour;
		public PowerUpController(PowerUpBehaviour behaviour)
		{
			this.behaviour = behaviour;
		}
		
		public override void DoOperation(PowerUpBehaviour behaviour)
		{

		}
	}
}

