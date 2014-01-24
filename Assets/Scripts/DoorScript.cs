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

	void OnMouseDown()
	{
		Debug.Log( "Door clicked." );
		PlayerController.CharacterView view = mPlayerController.GetView();
		if ( view == PlayerController.CharacterView.Cat )
		{
			mPlayerController.SwitchView( PlayerController.CharacterView.Grandma );
		}

		else if ( view == PlayerController.CharacterView.Grandma )
		{
			mPlayerController.SwitchView( PlayerController.CharacterView.Kid );
		}

		else if ( view == PlayerController.CharacterView.Kid )
		{
			mPlayerController.SwitchView( PlayerController.CharacterView.Cat );
		}

	}


}
