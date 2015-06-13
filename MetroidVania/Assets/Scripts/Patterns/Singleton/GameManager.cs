using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	public CheckPointOriginator checkPointOriginator;
	public CheckPointCareTaker checkPointCareTaker;

	private InputHandler inputHandler;
	private GameObject player;

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

	void Start()
	{
		setCheckPoint();
		inputHandler = new InputHandler();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public static void setCheckPoint()
	{
		if(instance.checkPointOriginator ==null)
			instance.checkPointOriginator = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckPointOriginator>();
		if(instance.checkPointCareTaker == null)
			instance.checkPointCareTaker = new CheckPointCareTaker();
		instance.checkPointCareTaker.Memento = instance.checkPointOriginator.CreateMemento();
	}

	public static void restoreCheckPoint()
	{
		instance.checkPointOriginator.SetMemento(instance.checkPointCareTaker.Memento);
	}

	void FixedUpdate()
	{
		Command command = inputHandler.HandleInput();
		//check if there is ANY type of command being executed.
		if(command!=null){
			command.Execute(player);
		}
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

	
}
