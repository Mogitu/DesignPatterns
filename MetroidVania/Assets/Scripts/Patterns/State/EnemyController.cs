using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
[RequireComponent(typeof (EnemyPathFinding))]
[RequireComponent(typeof (PlatformerCharacter2D))]

public class EnemyController : MonoBehaviour {

	GameObject player;
	private AIState state;
	private EnemyPathFinding pathfinding;
	[HideInInspector]
	public PlatformerCharacter2D character;
	// Use this for initialization
	void Start () {
		player =  GameObject.Find("Player");
		State = new IdleAIState();
		pathfinding = GetComponent<EnemyPathFinding>();
		character = GetComponent<PlatformerCharacter2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		state.Handle(this,pathfinding);
	}

	public AIState State
	{
		get{return state;}
		set{state = value;
			state.init(this,pathfinding);
		}
	}
}
