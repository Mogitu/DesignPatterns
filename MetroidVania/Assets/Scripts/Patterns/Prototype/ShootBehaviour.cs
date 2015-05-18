using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class ShootBehaviour : MonoBehaviour {

	[Range(1,30)]
	public float timeBetweenShooting = 4;
	float timeSinceLastShot = 0;
	private Animator animator;
	private Transform releasePoint;
	public GameObject arrowPrefab;
	// Use this for initialization
	void Start () 
	{
		foreach(Transform child in transform)
		{
			if(child.name.Equals("ArrowReleasePoint"))
				releasePoint = child;
		}
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timeSinceLastShot>0)timeSinceLastShot-=Time.deltaTime;
		if(timeSinceLastShot<=0 && Input.GetButtonDown("Fire1"))
		{
			animator.SetTrigger("Shoot");
		}
	}

	public void ShootArrow()
	{
		if(GetComponent<PlatformerCharacter2D>().m_FacingRight)Instantiate(arrowPrefab,releasePoint.position,releasePoint.rotation);
		else
		{
			GameObject arrow = (GameObject)Instantiate(arrowPrefab,releasePoint.position,releasePoint.rotation);
			arrow.transform.eulerAngles = new Vector3(arrow.transform.eulerAngles.x,arrow.transform.eulerAngles.y,-arrow.transform.eulerAngles.z+180);
		}
	}
}
