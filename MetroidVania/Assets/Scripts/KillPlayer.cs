using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag=="Player")
			collider.gameObject.GetComponent<DieBehaviour>().Kill("fell down the pitt of doom");
	}
}
