using UnityEngine;
using System.Collections;

/**
 *Object pool for testing. 
 *Objects are currently still coupled to the pool.
*/
public class ObjectPool : MonoBehaviour
{
	public TestObject prefab;
	public int instanceCount = 10;
	private TestObject[] instances;
	public static Vector3 stackPosition = new Vector3 (-9999, -9999, -9999);
	static float power = 10;

	void Start ()
	{
		instances = new TestObject[instanceCount];
		for (var i = 0; i < instanceCount; i++) 
		{
			instances [i] = Instantiate (prefab);
			//instances[i] = Instantiate(prefab, stackPosition, Quaternion.identity);
			//object are by default not enabled
			instances [i].enabled = false;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			TestObject obj = GetNextAvailableInstance ();
			if (obj != null) {
				obj.Initialize (transform, power);
			}
		}                                                              
	}

	//loop through all object to find the first available one
	//can be improved by using a (linked)list
	public  TestObject GetNextAvailableInstance ()
	{
		for (int i=0; i< instanceCount; i++) 
		{
			if (!instances [i].enabled) 
			{
				return instances [i];
			}
		}
		return null;
	}
}