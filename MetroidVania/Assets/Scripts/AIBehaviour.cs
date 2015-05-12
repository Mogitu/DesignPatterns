using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class AIBehaviour : MonoBehaviour {

	private PlatformerCharacter2D m_Character;
	private GameObject follow;
	// Use this for initialization
	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
		follow = null;
	}
	
	
	private void Update()
	{
		/*if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
		}*/
	}
	
	
	private void FixedUpdate()
	{
		// Read the inputs.
		/*bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;*/
		if(follow != null)
		{
			float x = follow.transform.position.x - transform.position.x;
			if( x > 2 || x < -2)
			{
				if(x > 0)
					x = 1;
				else
					x = -1;
				
				m_Character.Move(x, false, false);
			}
			else
				m_Character.Move(0, false, false);
		}
		else
			m_Character.Move(0, false, false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
			follow = other.gameObject;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
			follow = null;
	}

}
