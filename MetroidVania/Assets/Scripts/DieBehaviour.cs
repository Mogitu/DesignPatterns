using UnityEngine;
using System.Collections;

public class DieBehaviour : MonoBehaviour {
	
	private Animator animator;
	private bool isDying = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("Kill",false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KillPlayer(string reason)
	{
		if(animator.GetBool("Kill") || isDying)return;
		isDying = true;
		print("You got killed because " + reason);
		animator.SetTrigger("Kill");
	}

	public void resetPosition()
	{
		print ("You are back at the last spawnpoint");
		GameManager.restoreCheckPoint();
		isDying = false;
	}
}
