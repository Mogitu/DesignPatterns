using UnityEngine;
using System.Collections;

public abstract class AIState  
{
	public abstract void init(EnemyController controller,EnemyPathFinding pathfinding);
	public abstract void Handle(EnemyController controller,EnemyPathFinding pathfinding);
}
