using UnityEngine;
using System.Collections;

public class KillOnHitBehaviour : MonoBehaviour {

	
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		DieBehaviour die = collider.gameObject.GetComponent<DieBehaviour>();
		if(die)die.Kill("fell down the pitt of doom");
	}
}
