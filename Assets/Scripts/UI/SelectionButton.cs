using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class SelectionButton : MonoBehaviour 
{
	public enum ButtonType
	{
		Google,
		Achievements,
		Grandma,
		Girl,
		Cat

	}
	public ButtonType Type;

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
		Debug.Log( "Button pressed" );
		switch ( Type )
		{
			// Google sign in/out
		case ButtonType.Google:
		{
			if ( !((PlayGamesPlatform) Social.Active).IsAuthenticated() )
			{
				Social.localUser.Authenticate(( bool bSuccess ) =>
				                              {
					if ( bSuccess )
					{
						
					}
					
					else
					{
						
					}
				}
				);
			}

			else
			{
				((PlayGamesPlatform) Social.Active).SignOut();
			}

		} break;

		case ButtonType.Achievements:
		{
			if ( !((PlayGamesPlatform) Social.Active).IsAuthenticated() )
			{
				Social.localUser.Authenticate(( bool bSuccess ) =>
				                              {
					if ( bSuccess )
					{
						Social.ShowAchievementsUI();
					}
					
					else
					{
						
					}
				}
				);
			}
			
			else
			{
				Social.ShowAchievementsUI();
			}
		} break;

		case ButtonType.Girl:
		{
			Events.instance.Raise( new ViewSelectedEvent( CharacterView.Child ) );
		} break;

		case ButtonType.Cat:
		{
			Events.instance.Raise( new ViewSelectedEvent( CharacterView.Cat ) );
		} break;

		case ButtonType.Grandma:
		{
			Events.instance.Raise( new ViewSelectedEvent( CharacterView.Grandma ) );
		} break;

	}
	}
}