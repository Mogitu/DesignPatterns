using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.name=="Player")
			GameManager.restoreCheckPoint();
	}
}
