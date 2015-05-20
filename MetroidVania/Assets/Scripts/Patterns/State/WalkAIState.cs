using UnityEngine;
using System.Collections;

public class WalkAIState : AIState 
{
	float timer;
	private float direction;
	public override void init(EnemyController controller,EnemyPathFinding pathfinding)
	{
		UnityEngine.Debug.Log("LOL, I'm starting Walk State");
		timer = Random.Range(4,8);
		direction = Random.Range(0,2)==0 ? -1 : 1;
	}
	
	public override void Handle(EnemyController controller,EnemyPathFinding pathfinding)
	{
		timer-= Time.deltaTime;
		if(timer<=0)
			controller.State = new IdleAIState();
		if(controller.transform.position.x > pathfinding.rightLimit)
			direction = -1;
		
		else if(controller.transform.position.x < pathfinding.leftLimit)
			direction = 1;
		controller.character.Move(direction,false,false,false);
		UnityEngine.Debug.Log("LOL, I'm am now in walk State");
	}
}
