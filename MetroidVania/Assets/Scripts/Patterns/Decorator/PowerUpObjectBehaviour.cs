using UnityEngine;
using System.Collections;

public class PowerUpObjectBehaviour : MonoBehaviour {

	public PowerUpBehaviour.PowerUpType type;
	[Range(2.5f,60)]
	public float duration = 10;
	public bool oneTime = true;
	private Transform[] particles = new Transform[4];
	void Start()
	{
		Color color = Color.white;
		switch(type)
		{
		case PowerUpBehaviour.PowerUpType.DOUBLEJUMP:
			color = Color.yellow;
			break;
		case PowerUpBehaviour.PowerUpType.JUMPHIGHER:
			color = Color.green;
			break;
		case PowerUpBehaviour.PowerUpType.WALKFASTER:
			color = Color.red;
			break;
		default:break;
		}
		int x = 0;
		foreach(Transform child in transform)
		{
			particles[x++] = child;
			child.GetComponent<ParticleSystem>().startColor = color;
		}
	}
	public void OnTriggerEnter2D(Collider2D collider)
	{
		PowerUpBehaviour pu = collider.gameObject.GetComponent<PowerUpBehaviour>();
		if(pu)
		{
			pu.AddPowerUp(type,duration);
			if(oneTime)
				Destroy(gameObject);
			else
			{
				Invoke("activateAgain",duration);
				StartCoroutine(turnOff());
			}
		}
	}

	IEnumerator turnOff()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		float timer = 1;
		while(timer>0.1f)
		{
			timer-=Time.deltaTime;
			for(int i = 0;i<4;i++)
			{
				particles[i].localPosition = particles[i].localPosition.normalized*timer;
			}
			yield return 1;
		}
		gameObject.SetActive(false);
	}

	IEnumerator turnOn()
	{
		float timer = 0.1f;
		while(timer<=1)
		{
			timer+=Time.deltaTime;
			for(int i = 0;i<4;i++)
			{
				particles[i].localPosition = particles[i].localPosition.normalized*timer;
			}
			yield return 1;
		}
		
		for(int i = 0;i<4;i++)
			particles[i].localPosition = particles[i].localPosition.normalized;
		GetComponent<CircleCollider2D>().enabled = true;
	}

	void activateAgain()
	{
		gameObject.SetActive(true);
		StartCoroutine(turnOn());
	}

	void Update()
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z+1);
	}
}
