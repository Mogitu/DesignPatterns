using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public GameObject runPastParticles;
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.name=="Player")
		{
			GameManager.setCheckPoint();
			Instantiate(runPastParticles,transform.position+new Vector3(0,0.2f,0.1f),Quaternion.identity);
		}
	}
}
