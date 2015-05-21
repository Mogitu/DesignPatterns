using UnityEngine;
using System.Collections;

public class propsCreator : Creator {

	
	Sprite[] propSprites;
	public enum propTypes
	{
		Barrel,Sacks,Vase
	}

	public void setPropSprites(Sprite[] sprites)
	{
		propSprites = sprites;
	}

	public override Product FactoryMethod(Vector3 position, Vector3 scale)
	{
		GameObject gameObject = new GameObject();
		gameObject.transform.position = position;
		gameObject.transform.localScale = scale;
		SpriteRenderer sr =gameObject.AddComponent<SpriteRenderer> ();
		sr.sprite = propSprites [Random.Range (0, 3)];

		return new propsProduct ();
	}
}
