using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	bool bActive = false;
	public PlayerController mPlayerController;

	// Use this for initialization
	void Start () 
	{
		bActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D( Collider2D collision )
	{
		Events.instance.Raise(new SelectViewEvent());
		bActive = false;
	}

	void OnTriggerExit2D( Collider2D collision )
	{
		bActive = true;
	}

	void OnMouseDown()
	{
		return;
		Debug.Log( "Door clicked." );
		CharacterView view = mPlayerController.GetView();
		if ( view == CharacterView.Cat )
		{
			mPlayerController.SwitchView( CharacterView.Grandma );
		}

		else if ( view == CharacterView.Grandma )
		{
			mPlayerController.SwitchView( CharacterView.Kid );
		}

		else if ( view == CharacterView.Kid )
		{
			mPlayerController.SwitchView( CharacterView.Cat );
		}

	}


}
