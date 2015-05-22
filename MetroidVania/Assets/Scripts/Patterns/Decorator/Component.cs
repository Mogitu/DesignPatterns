using UnityEngine;
using System.Collections;

namespace Decorator
{
	public abstract class Component 
	{
		public abstract void DoOperation(PowerUpBehaviour behaviour);
	}
}

