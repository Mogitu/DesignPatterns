using UnityEngine;
using System.Collections;

public class IdleAIState : AIState 
{
	private float timer;
	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		timer = Random.Range(1,4);
	}

	public override void Handle(EnemyController controller,EnemyPathFinding pathfinding,bool incomingArrow)
	{
		timer-= Time.deltaTime;
		//Check if we need to switch states
		if(incomingArrow)
			controller.State = new AvoidAIState();
		else if(controller.isPlayerNearAndTargetable())
			controller.State = new AttackAIState();
		else if(timer<=0)
			controller.State = new WalkAIState();
		
		//Handle the state we are in
		controller.character.Move(0,false,false,false);
	}
}
