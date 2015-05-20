using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
[RequireComponent(typeof (EnemyPathFinding))]
[RequireComponent(typeof (PlatformerCharacter2D))]

public class EnemyController : MonoBehaviour {

	public GameObject player;
	private AIState state;
	private EnemyPathFinding pathfinding;
	[HideInInspector]
	public PlatformerCharacter2D character;
	[Range(8,60)]
	public float attackDistance = 5;
	[Range(2,5)]
	public float maxHeightDistance = 2;
	public bool incomingArrow = false;

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
		//Currently disabled since it fails..
		//state.Handle(this,pathfinding,incomingArrow);
		state.Handle(this,pathfinding,false);
		incomingArrow = false;
	}

	public AIState State
	{
		get{return state;}
		set{state = value;
			state.init(this,pathfinding);
		}
	}

	public bool isPlayerNearAndTargetable()
	{
		if(Vector3.Distance(player.transform.position,transform.position)<attackDistance && Mathf.Abs(player.transform.position.y - transform.position.y)<maxHeightDistance)
			return true;
		return false;
	}
}
