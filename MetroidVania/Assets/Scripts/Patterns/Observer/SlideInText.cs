using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlideInText : MonoBehaviour 
{
	public float Speed = 1.0f;

	private Vector3 from;
	private Vector3 to;
	private float startTime;
	private float journeyLength;
	RectTransform textTrans;

	void Start () 
	{
		startTime = Time.time;
		journeyLength = Vector3.Distance(from, to);
		textTrans = transform as RectTransform;

		to = textTrans.localPosition;
		from = to + new Vector3(textTrans.rect.width, 0, 0);
		textTrans.localPosition = from;

		Invoke("DestroyGUI", 10);
	}

	void Update () 
	{
		float distCovered = (Time.time - startTime) * Speed;
		float fracJourney = distCovered / journeyLength;
		textTrans.localPosition = Vector3.Lerp(from, to, fracJourney);
	}

	public void DestroyGUI()
	{
		Destroy(gameObject);
	}
}
