using UnityEngine;
using System.Collections;

public class AchievementManager : MonoBehaviour 
{
	void Start () 
	{
		//Attach kill achievements to the enemy subject
		Achievement[] kAchievs = GameObject.Find("KillRelatedAchievements").GetComponents<Achievement>();
		GameObject enemies = GameObject.Find("Enemies");

		if(kAchievs.Length == 0 || !enemies)
			return;

		EnemySubject eSub = enemies.GetComponent<EnemySubject>();

		if(eSub != null)
		{
			for (int j = 0; j < kAchievs.Length; j++) 
			{
				eSub.attach(kAchievs[j]);
			}
		}
	}
}
