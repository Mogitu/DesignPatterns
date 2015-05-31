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
	private RectTransform textTrans;
	private Text text;

	void Awake()
	{
		textTrans = transform as RectTransform;
		text = GetComponent<Text>();
	}

	void Update () 
	{
		float distCovered = (Time.time - startTime) * Speed;
		float fracJourney = distCovered / journeyLength;

		if(float.IsNaN(fracJourney) || float.IsInfinity(fracJourney))
			return;

		textTrans.localPosition = Vector3.Lerp(from, to, fracJourney);

	}

	public void SlideIn(string message)
	{
		this.enabled = true;

		text.text = message;

		startTime = Time.time;
		from = textTrans.localPosition;
		to = from - new Vector3(textTrans.rect.width, 0, 0);
		journeyLength = Vector3.Distance(from, to);

		Invoke("SlideOut", 10);
	}
	
	public void SlideOut()
	{
		startTime = Time.time;
		from = textTrans.localPosition;
		to = from + new Vector3(textTrans.rect.width, 0, 0);
		journeyLength = Vector3.Distance(from, to);

		Invoke("disableScript", 10);
	}

	public void disableScript()
	{
		//No need to keep updating it when it's outside of the screen
		this.enabled = false;
	}

	public void DestroyGUI()
	{
		Destroy(gameObject);
	}
}
