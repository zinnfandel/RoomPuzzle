using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	enum CharacterView
	{
		Cat,
		Kid,
		Grandma
	};
	CharacterView mCharacterView;

	// Use this for initialization
	void Start () 
	{
		mCharacterView = CharacterView.Kid;
		ShowKidView();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		Debug.Log( "Door clicked." );
		if ( mCharacterView == CharacterView.Cat )
		{
			SwitchView( CharacterView.Grandma );
		}

		else if ( mCharacterView == CharacterView.Grandma )
		{
			SwitchView( CharacterView.Kid );
		}

		else if ( mCharacterView == CharacterView.Kid )
		{
			SwitchView( CharacterView.Cat );
		}

	}

	void SwitchView( CharacterView view )
	{
		mCharacterView = view;

		if ( view == CharacterView.Kid )
		{
			ShowKidView();
		}

		else if ( view == CharacterView.Grandma )
		{
			ShowGrandmaView();
		}

		else if ( view == CharacterView.Cat )
		{
			ShowCatView();
		}
	}

	void ShowKidView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Kid" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Cat" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Grandma" ) );
	}

	void ShowGrandmaView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Cat" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Grandma" ) );
	}

	void ShowCatView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Grandma" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
	}
}
