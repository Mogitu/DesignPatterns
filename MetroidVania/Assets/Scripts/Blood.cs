﻿using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {

	ParticleSystem ps;
	// Use this for initialization
	void Start () 
	{
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ps.isStopped)
			Destroy(gameObject);
	}
}
