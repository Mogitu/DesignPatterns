using UnityEngine;
using System.Collections;

public class FlyWeightObj : MonoBehaviour {

	// Use this for initialization
	public GameObject obj;
	private SpriteRenderer rend;
	private SpriteRenderer other;
	void Start () {
	    rend = GetComponent<SpriteRenderer>();
		other = obj.GetComponent<SpriteRenderer>();
		rend.sprite = other.sprite;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
