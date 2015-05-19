using UnityEngine;
using System.Collections;

public class DieBehaviour : MonoBehaviour {
	
	private Animator animator;
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
		if(animator.GetBool("Kill"))return;
		print("You got killed because " + reason);
		animator.SetBool("Kill",true);
	}

	public void resetPosition()
	{
		print ("You are back at the last spawnpoint");
		GameManager.restoreCheckPoint();
		animator.SetBool("Kill",false);
	}
}
