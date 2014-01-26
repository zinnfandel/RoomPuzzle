using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public enum CharacterView
{
	None,
	Cat,
	Child,
	Grandma
};

public class PlayerController : MonoBehaviour 
{
	public static PlayerController s_PlayerController = null;

	public Transform 	mTargetPosition;
	public Player		mPlayer;

	private bool _active;

	CharacterView mCharacterView;

	bool mPickupIssued;
	Pickupable mPickupTarget;

	public CharacterView GetView() { return mCharacterView; }
	// Use this for initialization
	void Start () 
	{
		s_PlayerController = this;

		mPickupIssued = false;
		mPickupTarget = null;
		Events.instance.AddListener<ViewSelectedEvent>(OnViewSelected);
		Events.instance.AddListener<SelectViewEvent>(OnViewSelecting);
		mCharacterView = CharacterView.None;
	}

	public void Pickup( Pickupable pTarget )
	{
		mPickupIssued = true;
		mPickupTarget = pTarget;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!_active) return;

		//GetComponent<Animator>().Play(Walking.name);
		if ( Input.GetMouseButtonDown( 0 ) )
		{

			Vector3 vWorldMousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			vWorldMousePosition.z = 0.0f;
			mTargetPosition.position = vWorldMousePosition;
			mPlayer.WalkTo( vWorldMousePosition );

			if ( mPickupIssued )
			{
				mPickupIssued = false;
			}

			else
			{
				mPickupTarget = null;
			}

			Events.instance.Raise(new PlaySoundEvent(SoundLibrarySelection.Meow));
		}

		else if ( mPickupTarget != null && mPlayer.IsWalking() == false )
		{
			mPickupTarget.Pickup();
			mPickupTarget = null;
		}
	}

	void OnMouseDown() 
	{

	}

	public void OnViewSelected(ViewSelectedEvent e)
	{
		_active = true;
		SwitchView(e.View);
	}

	public void OnViewSelecting(SelectViewEvent e)
	{
		_active = false;
	}

	public void SwitchView( CharacterView view )
	{
		if ( mCharacterView == CharacterView.None )
		{
			string code = " ";
			switch ( view )
			{
			case CharacterView.Cat:
				code = "CggIirmgxisQAhAA";
				break;

			case CharacterView.Child:
				code = "CggIirmgxisQAhAC";
				break;

			case CharacterView.Grandma:
				code = "CggIirmgxisQAhAB";
				break;
			}

			Social.ReportProgress( code, 100.0f, ( bool success ) => 
			{
				// handle success or failure
			});
		}

		mCharacterView = view;

		Pickupable.ClearCurrent();
		
		if ( view == CharacterView.Child )
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
