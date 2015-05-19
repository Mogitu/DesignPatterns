using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.name=="Player")
			collider.gameObject.GetComponent<DieBehaviour>().KillPlayer("you fell down the pitt of doom");
	}
}
