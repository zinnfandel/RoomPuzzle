using UnityEngine;
using System.Collections;

public class Usable : MonoBehaviour 
{
	public Pickupable UsedWith = null;
	public GameObject Reveals = null;
	public CharacterView UsedBy;
	public bool DisableAfterUse = false;
	public GameObject	HighlightObject;

	private GameObject mHighlightObjectInstance;
	private bool		mWasUsed;
	// Use this for initialization
	void Start () 
	{
		mWasUsed = false;
		if ( HighlightObject )
		{
			mHighlightObjectInstance = Instantiate( HighlightObject, transform.position, Quaternion.identity ) as GameObject;
			mHighlightObjectInstance.transform.parent = this.transform;
			mHighlightObjectInstance.SetActive( false );
			Events.instance.AddListener<ViewSelectedEvent>(OnViewSelectedEvent);
			Events.instance.AddListener<SelectPickupEvent>(OnSelectPickupEvent);
		}
	}

	void OnSelectPickupEvent( SelectPickupEvent pickupEvent )
	{
		HandleHighlightVisibility( PlayerController.s_PlayerController.GetView() );
	}

	void HandleHighlightVisibility( CharacterView view )
	{
		if ( UsedWith == null )
		{
			Debug.Log( "NONE!" );
		}

		if ( mHighlightObjectInstance != null && !mWasUsed && ( UsedWith == null || UsedWith == Pickupable.GetCurrent() ) )
		{
			if ( view == UsedBy )
			{
				mHighlightObjectInstance.SetActive( true );
			}
			
			else
			{
				mHighlightObjectInstance.SetActive( false );
			}
		}
	}

	void OnViewSelectedEvent( ViewSelectedEvent e )
	{
		HandleHighlightVisibility( e.View );
	}

	void OnEnable()
	{
		if ( PlayerController.s_PlayerController.GetView() != null )
		{
			HandleHighlightVisibility( PlayerController.s_PlayerController.GetView() );
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log( "Usable clicked" );
		if ( PlayerController.s_PlayerController.GetView() == UsedBy )
		{
			Debug.Log( "Usable by right user" );
			if ( UsedWith == null || UsedWith == Pickupable.GetCurrent() )
			{
				Debug.Log( "Usable activated" );
				if ( UsedWith )
				{
					UsedWith.gameObject.SetActive( false );
				}

				if ( Reveals )
				{
					Reveals.SetActive( true );
				}

				if ( DisableAfterUse )
				{
					this.gameObject.SetActive( false );
				}

				mWasUsed = true;
				if ( mHighlightObjectInstance != null )
				{
					mHighlightObjectInstance.SetActive( false );
				}
			}
		}
	}
}
