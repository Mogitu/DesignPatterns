using UnityEngine;
using System.Collections;

public class WalkAIState : AIState 
{
	float timer;
	private float direction;
	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		timer = Random.Range(4,8);
		direction = Random.Range(0,2)==0 ? -1 : 1;
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
			controller.State = new IdleAIState();
		//Handle the state we are in
		if(controller.transform.position.x > pathfinding.rightLimit)
			direction = -1;
		
		else if(controller.transform.position.x < pathfinding.leftLimit)
			direction = 1;
		controller.character.Move(direction,false,false,false);
	}
}
