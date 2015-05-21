using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {
	propsCreator creator;public float testFloat = 6;
	[Range(0,30)]
	public float testFloat2 = 6;
	public string testString = "tesetets";
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
