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
	public CheckPointOriginator checkPointOriginator;
	public CheckPointCareTaker checkPointCareTaker;

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

	void Awake()
	{
		instance = this;
	}

	public static void setCheckPoint()
	{
		if(instance.checkPointOriginator ==null)
			instance.checkPointOriginator = GameObject.Find("Player").GetComponent<CheckPointOriginator>();
		if(instance.checkPointCareTaker == null)
			instance.checkPointCareTaker = new CheckPointCareTaker();
		instance.checkPointCareTaker.Memento = instance.checkPointOriginator.CreateMemento();
	}

	public static void restoreCheckPoint()
	{
		instance.checkPointOriginator.SetMemento(instance.checkPointCareTaker.Memento);
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

	void UpdatePlaying()
	{
	}

	void UpdatePaused(){
	}

	void UpdateGameOver(){
	}
}
