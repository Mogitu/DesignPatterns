using UnityEngine;
using System.Collections;

namespace Decorator
{
	public abstract class PowerUp : Component 
	{
		public Component next;
		public Component prev;
		public float timer;
		public PowerUp(PowerUpBehaviour behaviour,Component component,float timeAlive)
		{
			prev = component;
			if(prev.GetType()==(typeof(PowerUp)))
			{
				(prev as PowerUp).next = this;
			}
			timer = timeAlive;
		}

		public override void DoOperation(PowerUpBehaviour behaviour)
		{
			prev.DoOperation(behaviour);
			timer-=Time.deltaTime;
			if(timer<=0)removePowerUp(behaviour);
		}

		public virtual void removePowerUp(PowerUpBehaviour behaviour)
		{
			if(next != null && prev.GetType()==(typeof(PowerUp)))
			{
				(prev as PowerUp).next = next;
			}
			if(prev != null && next != null)
			{
				(next as PowerUp).prev = prev;
			}
			if(prev.GetType()==(typeof(PowerUpController)) && next == null)
			{
				behaviour.controller = prev;
			}
		}
	}
}

