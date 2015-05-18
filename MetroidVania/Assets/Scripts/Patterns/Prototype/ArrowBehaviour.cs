using UnityEngine;
using System.Collections;

public class ArrowBehaviour : MonoBehaviour {

	public float speed = 30;
	private bool hasLanded = false;
	Rigidbody2D body;
	BoxCollider2D collider;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasLanded)
		{
			transform.position = transform.position + transform.right * speed* Time.deltaTime;
			Vector3 rot = transform.eulerAngles;
			if(rot.z<90)rot.z-= 30*Time.deltaTime;
			else if(rot.z<180)rot.z+=30*Time.deltaTime;
			else if(rot.z<270)rot.z+=60*Time.deltaTime;
			else rot.z-=60*Time.deltaTime;
			transform.eulerAngles = rot;
		}

	}

	public void OnCollisionEnter2D(Collision2D collider)
	{
		if(hasLanded)return;
		if(collider.gameObject.name=="Player")
			GameManager.restoreCheckPoint();
		else
		{
			hasLanded = true;
			body.isKinematic = true;
			this.collider.enabled = false;
			transform.parent = collider.transform;
		}
	}
}
