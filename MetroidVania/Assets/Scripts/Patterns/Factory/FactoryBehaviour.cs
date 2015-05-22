using UnityEngine;
using System.Collections;

public class FactoryBehaviour : MonoBehaviour {
	propsCreator creator;
	public Sprite[] propSprites;
	// Use this for initialization
	void Start () {
		creator = new propsCreator ();
		GameObject[] tempProps = GameObject.FindGameObjectsWithTag("tempProp");
		creator.setPropSprites(propSprites);
		for (int i = 0; i < tempProps.Length; i++)
		{
			creator.FactoryMethod (tempProps[i].transform.position,tempProps[i].transform.localScale);
			Destroy(tempProps[i]);
		}
	}
}
