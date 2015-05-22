using UnityEngine;
using System.Collections;
namespace Decorator
{
	public class WalkFasterPowerUp : PowerUp
	{
		const float speedToAdd = 10;
		public WalkFasterPowerUp(PowerUpBehaviour behaviour,Component component,float timeAlive):base(behaviour,component,timeAlive)
		{
			behaviour.character.MaxSpeed += speedToAdd;
		}
		public override void DoOperation(PowerUpBehaviour behaviour)
		{
			base.DoOperation(behaviour);
		}
		
		public override void removePowerUp(PowerUpBehaviour behaviour)
		{
			base.removePowerUp(behaviour);
			behaviour.character.MaxSpeed -= speedToAdd;
		}
	}
}
