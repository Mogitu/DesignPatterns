using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.name=="Player")
			GameManager.setCheckPoint();
	}
}
