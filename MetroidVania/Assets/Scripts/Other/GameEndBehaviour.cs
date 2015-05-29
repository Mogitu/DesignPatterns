using UnityEngine;
using System.Collections;

public class GameEndBehaviour : MonoBehaviour {

	GameObject player;
	float particleSize = 0.5f;
	float particleSizeIncreasePerLayer = 0.75f;
	bool inTransition = false;
	bool isOn = true;
	bool isEnding = false;
	public float activationDistance = 15;
	public float transitionTime = 1;
	public float endTransitionTime = 3;
	public string nextLevel;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		int x =1;
		foreach(Transform child in transform)
		{
			child.eulerAngles = new Vector3(child.eulerAngles.x,child.eulerAngles.y,child.eulerAngles.z+x);
			x = -x;
		}
		if(Vector3.Distance(player.transform.position,transform.position)<activationDistance && !inTransition && !isOn)
			StartCoroutine(turnOn());
		if(Vector3.Distance(player.transform.position,transform.position)>activationDistance && !inTransition && isOn)
			StartCoroutine(turnOff());
		if(Vector3.Distance(player.transform.position,transform.position)<=3 && !isEnding)
			StartCoroutine(endLevel());
	}

	IEnumerator endLevel()
	{
		isEnding = true;
		player.GetComponent<Rigidbody2D>().isKinematic = true;
		float timer = 1;
		AsyncOperation async = Application.LoadLevelAsync(nextLevel);
		async.allowSceneActivation = false;
		while(timer>0.1f || !async.isDone)
		{
			timer-=Time.deltaTime/endTransitionTime;
			if(timer<0.1f)
				timer=0.1f;
			else if(timer<0.5f)
				async.allowSceneActivation = true;
			player.transform.Rotate(Vector3.forward,720*Time.deltaTime);
			player.transform.RotateAround(transform.position,Vector3.forward,360*Time.deltaTime);
			player.transform.position = player.transform.position + (transform.position-player.transform.position)*Time.deltaTime;
			player.transform.localScale = new Vector3(0.1f+timer*0.9f,0.1f+timer*0.9f,0.1f+timer*0.9f);
			yield return 1;
		}
	}
	
	
	IEnumerator turnOff()
	{
		inTransition = true;
		float timer = 1;
		while(timer>0.1f)
		{
			timer-=Time.deltaTime;

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
		foreach(Transform child in transform)
			child.gameObject.SetActive(false);
		inTransition = false;
		isOn = false;
	}
	
	IEnumerator turnOn()
	{
		inTransition = true;
		foreach(Transform child in transform)
			child.gameObject.SetActive(true);
		float timer = 0.1f;
		while(timer<=1)
		{
			timer+=Time.deltaTime;
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

		inTransition = false;
		isOn = true;
	}
}
