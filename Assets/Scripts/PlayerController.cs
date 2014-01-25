using UnityEngine;
using System.Collections;

public enum CharacterView
{
	Cat,
	Kid,
	Grandma
};

public class PlayerController : MonoBehaviour 
{
	public static PlayerController s_PlayerController;

	public Transform 	mTargetPosition;
	public Player		mPlayer;


	CharacterView mCharacterView;

	public CharacterView GetView() { return mCharacterView; }
	// Use this for initialization
	void Start () 
	{
		s_PlayerController = this;
		Events.instance.AddListener<ViewSelectedEvent>(OnViewSelected);
		SwitchView( CharacterView.Kid );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			Vector3 vWorldMousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			vWorldMousePosition.z = 0.0f;
			Debug.Log( vWorldMousePosition );
			mTargetPosition.position = vWorldMousePosition;
			mPlayer.WalkTo( vWorldMousePosition );

			Events.instance.Raise(new PlaySoundEvent(SoundLibrarySelection.Meow));
		}
	}

	void OnMouseDown() 
	{
	}

	public void OnViewSelected(ViewSelectedEvent e)
	{
		SwitchView(e.View);
	}

	public void SwitchView( CharacterView view )
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
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Grandma" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Cat" ) );
	}
	
	void ShowCatView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Cat" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Grandma" ) );
	}
}
