﻿using UnityEngine;
using System.Collections;

public class ArrowBehaviour : MonoBehaviour {
	[Range(15,60)]
	public float speed = 30;
	[Range(5,60)]
	public float upwardDrag = 30;
	[Range(5,90)]
	public float downwardDrag = 60;
	private bool hasLanded = false;
	Rigidbody2D body;	BoxCollider2D collider;
	[Range(5,30)]
	public float timeAlive =5;
	private float timer;
	public LayerMask whatCanIHit;
	[Range(5,30)]
	public float avoidDistanceEnemies = 5;
	public GameObject blood;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>();
		timer = timeAlive;
	}
	
	// Update is called once per frame
	void Update () 
	{
			if(!hasLanded)
			{
				transform.position = transform.position + transform.right * speed* Time.deltaTime;
				Vector3 rot = transform.eulerAngles;
				if(rot.z<90)rot.z-= upwardDrag*Time.deltaTime;
				else if(rot.z<180)rot.z+=upwardDrag*Time.deltaTime;
				else if(rot.z<270)rot.z+=downwardDrag*Time.deltaTime;
				else rot.z-=downwardDrag*Time.deltaTime;
				transform.eulerAngles = rot;
				RaycastHit2D hit =   Physics2D.Raycast(transform.position,transform.right,avoidDistanceEnemies,whatCanIHit);
				if(hit.collider !=null)
					if(hit.collider.gameObject.GetComponent<EnemyController>()!=null)
						hit.collider.gameObject.GetComponent<EnemyController>().incomingArrow = true;
			}
			timer-= Time.deltaTime;
			if(timer<=0)
			{
				timer=timeAlive;
				this.collider.enabled = true;
				GetComponent<Rigidbody2D>().isKinematic = false;
				hasLanded=false;
				gameObject.SetActive(false);//Destroy(gameObject);
			}
	}

	public void OnCollisionEnter2D(Collision2D collider)
	{
		if(gameObject.activeSelf)
		{
			if(hasLanded)return;
			hasLanded = true;
			DieBehaviour die = collider.gameObject.GetComponent<DieBehaviour>();
			ArrowBehaviour arr = collider.gameObject.GetComponent<ArrowBehaviour>();
			if(die!=null)
			{
				Instantiate(blood,collider.contacts[0].point,Quaternion.identity);
				die.Kill(" got hit by an arrow");
				gameObject.SetActive(false);
			}
			if(arr != null){
				gameObject.SetActive(false);//Destroy(gameObject);
			}			
			this.collider.enabled = false;
			GetComponent<Rigidbody2D>().isKinematic = true;
			//transform.parent = collider.transform;
		}

	}
}
