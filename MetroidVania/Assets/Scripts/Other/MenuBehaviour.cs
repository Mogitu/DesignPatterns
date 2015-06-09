using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {

	bool isEnding =false;
	public void GoToLevel1()
	{
		if(!isEnding)StartCoroutine(startGame ());
	}

	IEnumerator startGame()
	{
		isEnding = true;
		float timer = 1;
		AsyncOperation async = Application.LoadLevelAsync("level1");
		while(!async.isDone)
			yield return 1;
	}
}
