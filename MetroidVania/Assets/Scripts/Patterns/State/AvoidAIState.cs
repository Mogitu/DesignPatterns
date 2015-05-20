using UnityEngine;
using System.Collections;

public class AvoidAIState : AIState 
{
	//timer is needed to avoid emmidiate switching to other states
	float timer;
	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		controller.character.Move(0,false,true,false);
		timer = 0.3f;
	}
	
	public override void Handle(EnemyController controller,EnemyPathFinding pathfinding,bool incomingArrow)
	{
		timer -=Time.deltaTime;
		//Check if we need to switch states
		if(timer<=0&&controller.character.Grounded)
			controller.State = new WalkAIState();
	}
}