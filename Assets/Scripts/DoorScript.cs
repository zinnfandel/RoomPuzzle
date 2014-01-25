using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	public PlayerController mPlayerController;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D( Collider2D collision )
	{
		Events.instance.Raise(new SelectViewEvent());
	}

	void OnTriggerExit2D( Collider2D collision )
	{
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
