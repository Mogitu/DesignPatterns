using UnityEngine;
using System.Collections;

public class KillOnHitBehaviour : MonoBehaviour {

	public string deadReason;
	public GameObject blood;
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		DieBehaviour die = collider.gameObject.GetComponent<DieBehaviour>();
		Instantiate(blood,transform.position,Quaternion.identity);
		if(die)die.Kill(deadReason);
	}
}
