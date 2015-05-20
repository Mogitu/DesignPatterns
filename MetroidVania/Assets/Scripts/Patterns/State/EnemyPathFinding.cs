using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyPathFinding : MonoBehaviour {

	private GameObject walkArea;
	[HideInInspector]
	public float leftLimit;
	[HideInInspector]
	public float rightLimit;
	//we need an offset so the enemy does not fall from its walkpath
	public static float offset = .9f;
	private bool checking = false;
	// Use this for initialization
	void Start () 
	{
		checkPathfinding();
	}

	public void checkPathfinding()
	{
		if(!checking)StartCoroutine(CheckWalkArea());
	}

	//Finding a walkingPath
	IEnumerator CheckWalkArea()
	{
		checking = true;
		walkArea = null;
		while(!walkArea)
		{
			yield return 1;
			Transform groundCheck = transform.Find("GroundCheck");
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, GetComponent<PlatformerCharacter2D>().k_GroundedRadius, GetComponent<PlatformerCharacter2D>().WhatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					Transform hit = colliders[i].transform;
					//find the upmost parent so we can cycle through all its children
					while(hit.parent !=null)
						hit = hit.parent;
					walkArea = hit.gameObject;
					//start by setting the limits to infinity
					leftLimit = Mathf.Infinity;
					rightLimit = Mathf.Infinity;
					//Finding the limits of the walkspace
					setLimits(walkArea);


					//checking for some obstructions on the walkspace to the right
					RaycastHit2D rHit = Physics2D.Raycast(new Vector2(groundCheck.position.x,transform.position.y),new Vector2(1,0),rightLimit- groundCheck.position.x,GetComponent<PlatformerCharacter2D>().WhatIsGround);
					if(rHit.collider!=null)
						rightLimit = rHit.point.x;
					//raycast to the left
					RaycastHit2D lHit = Physics2D.Raycast(new Vector2(groundCheck.position.x,transform.position.y),new Vector2(-1,0),groundCheck.position.x-leftLimit,GetComponent<PlatformerCharacter2D>().WhatIsGround);
					if(lHit.collider!=null)
						leftLimit = lHit.point.x;
					//apply offset 
					leftLimit+= offset;
					rightLimit-=offset;
					checking = false;
					break;
				}
			}
		}
	}

	void setLimits(GameObject obj)
	{
		if(obj.GetComponent<Renderer>())
		{
			//limits of this object
			float objLeft = obj.transform.position.x - obj.GetComponent<Renderer>().bounds.size.x/2;
			float objRight = obj.transform.position.x + obj.GetComponent<Renderer>().bounds.size.x/2;
			//set the limits if they are better than the current limits
			if(leftLimit==Mathf.Infinity || objLeft < leftLimit)
				leftLimit = objLeft;
			if(rightLimit==Mathf.Infinity || objRight > rightLimit)
				rightLimit = objRight;
		}
		//do this for all children
		foreach(Transform t in obj.transform)
			setLimits(t.gameObject);
	}
}
