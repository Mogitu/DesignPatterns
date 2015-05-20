using UnityEngine;
using System.Collections;

public class IdleAIState : AIState 
{
	private float timer;
	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		UnityEngine.Debug.Log("LOL, I'm starting Idle State");
		timer = Random.Range(1,4);
	}

	public override void Handle(EnemyController controller,EnemyPathFinding pathfinding)
	{
		timer-= Time.deltaTime;
		if(timer<=0)
			controller.State = new WalkAIState();
		controller.character.Move(0,false,false,false);
		UnityEngine.Debug.Log("LOL, I'm am now in Idle State");
	}
}
