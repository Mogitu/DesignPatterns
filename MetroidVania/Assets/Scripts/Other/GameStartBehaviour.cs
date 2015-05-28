using UnityEngine;
using System.Collections;

public class GameStartBehaviour : MonoBehaviour {

	GameObject player;
	float particleSize = 0.5f;
	float particleSizeIncreasePerLayer = 0.75f;
	bool inTransition = false;
	bool isOn = true;
	public float transitionTime = 3;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		transform.position = player.transform.position;
		float x = particleSize;
		Color color = Color.white;
		foreach(Transform child in transform)
		{
			child.localScale = new Vector3(x,x,x);
			foreach(Transform ch in child)
			{
				ch.GetComponent<ParticleSystem>().startColor = color;
				ch.GetComponent<ParticleSystem>().startSize = x*0.5f*transform.localScale.x;
			}
			color = new Color(1-color.r,1-color.g,1-color.b,color.a);
			x+=particleSizeIncreasePerLayer;
		}
		StartCoroutine(turnOff());
	}
	void Update () 
	{
		int x =1;
		foreach(Transform child in transform)
		{
			child.eulerAngles = new Vector3(child.eulerAngles.x,child.eulerAngles.y,child.eulerAngles.z+x);
			x = -x;
		}
	}
	
	
	IEnumerator turnOff()
	{
		inTransition = true;
		float timer = 1;
		while(timer>0.1f)
		{
			timer-=Time.deltaTime/transitionTime;
			
			float x = particleSize;
			foreach(Transform child in transform)
			{
				child.localScale = new Vector3(x,x,x);
				foreach(Transform ch in child)
				{
					ch.GetComponent<ParticleSystem>().startSize = x*0.5f*transform.localScale.x*timer;
					ch.localPosition = ch.localPosition.normalized*timer;
				}
				x+=particleSizeIncreasePerLayer;
			}
			yield return 1;
		}
		Destroy(gameObject);
	}
}
