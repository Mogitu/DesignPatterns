using UnityEngine;
using System.Collections;

public enum GameState{
  PLAYING,
  GAMEOVER,
  PAUSED
	//etc....
}

public class GameManager : MonoBehaviour {

	public GameState gameState = GameState.PLAYING;

	//Singleton instance
	private static GameManager instance =null;

	//Get the instance with an property
	public static GameManager GetInstance{
		get{
			//If there is no instance yet, find it in the scene hierarchy
			if(instance == null){
				instance = (GameManager)FindObjectOfType(typeof(GameManager));
			}
			//Return the instance
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //
		switch(gameState){
		case GameState.PLAYING:
			UpdatePlaying();
			break;
		case GameState.PAUSED:
			UpdatePaused();
			break;
		case GameState.GAMEOVER:
			UpdateGameOver();
			break;
		}	
	}

	void UpdatePlaying(){
	}

	void UpdatePaused(){
	}

	void UpdateGameOver(){
	}
}
