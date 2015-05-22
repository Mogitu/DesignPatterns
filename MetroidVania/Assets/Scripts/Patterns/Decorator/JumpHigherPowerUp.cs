using UnityEngine;
using System.Collections;
namespace Decorator
{
	public class JumpHigherPowerUp : PowerUp
	{
		const float forceToAdd = 400;
		public JumpHigherPowerUp(PowerUpBehaviour behaviour,Component component,float timeAlive):base(behaviour,component,timeAlive)
		{
			behaviour.character.JumpForce +=forceToAdd;
		}
		public override void DoOperation(PowerUpBehaviour behaviour)
		{
			base.DoOperation(behaviour);
		}

		public override void removePowerUp(PowerUpBehaviour behaviour)
		{
			base.removePowerUp(behaviour);
			behaviour.character.JumpForce -=forceToAdd;
		}
	}
}
