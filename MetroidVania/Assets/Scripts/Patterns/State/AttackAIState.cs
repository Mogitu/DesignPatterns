using UnityEngine;
using System.Collections;

public class AttackAIState : AIState 
{

	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		controller.character.Move((controller.transform.position.x-controller.player.transform.position.x)<0? 0.1f:-0.1f,false,false,true);
	}
	
	public override void Handle(EnemyController controller,EnemyPathFinding pathfinding,bool incomingArrow)
	{
		//Check if we need to switch states
		if(incomingArrow)
			controller.State = new AvoidAIState();
		else if(!controller.isPlayerNearAndTargetable())
			controller.State = new WalkAIState();
		
		//Handle the state we are in
		if(controller.character.m_FacingRight != (controller.transform.position.x-controller.player.transform.position.x)<0)
			controller.character.Move((controller.transform.position.x-controller.player.transform.position.x)<0? 0.1f:-0.1f,false,false,true);
		else controller.character.Move(0,false,false,true);
	}
}
