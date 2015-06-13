using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Author: Maikel van Munsteren
 * Desc:   Object pool, store x amount of assigned prefab and reuse them.
 * ToDo:   x
 * */
public class ObjectPool : MonoBehaviour
{


    public GameObject pooledObject;
    public int pooledAmount = 20;
    public bool willGrow = true;

    private List<GameObject> pooledObjects;

    //Singleton instance
    private static ObjectPool instance = null;

    //Get the instance with an property
    public static ObjectPool GetInstance
    {
        get
        {
            //If there is no instance yet, find it in the scene hierarchy
            if (instance == null)
            {
                instance = (ObjectPool)FindObjectOfType(typeof(ObjectPool));
            }
            //Return the instance
            return instance;
        }
    }
    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject getPooledObject()
    {
        //find available object
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        //if no available found and growing is allowed, create a new object
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        //if all fails
        return null;
    }

}
