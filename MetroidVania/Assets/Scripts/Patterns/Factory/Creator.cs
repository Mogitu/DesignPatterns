using UnityEngine;
using System.Collections;

public abstract class Creator {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	abstract public Product FactoryMethod(Vector3 position, Vector3 scale);
}
