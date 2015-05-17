using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour
{
	float gravity = 10.0f;
	float drag = 0.01f;
	float lifetime = 10.0f;
	Vector3 velocity;
	private float timer = 0.0f;                                                
	// Use this for initialization
	void Start ()
	{
	
	}
	//set default values and enable object
	public void Initialize (Transform parent, float speed)
	{
		transform.position = parent.position;
		transform.rotation = parent.rotation;
		velocity = parent.forward * speed;
		timer = 0;
		enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//make the object drop for testing purposes
		velocity -= velocity * drag * Time.deltaTime;
		velocity -= Vector3.up * gravity * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;

		//disable object when lifetime expires
		timer += Time.deltaTime;
		if (timer > lifetime) {
			transform.position = new Vector3 (999, 999, 999);
			enabled = false;
		}
	}
}
