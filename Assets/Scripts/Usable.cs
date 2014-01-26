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
		}
	}

	void OnViewSelectedEvent(ViewSelectedEvent e)
	{
		if ( mHighlightObjectInstance != null && !mWasUsed )
		{
			if ( e.View == UsedBy )
			{
				mHighlightObjectInstance.SetActive( true );
			}
			
			else
			{
				mHighlightObjectInstance.SetActive( false );
			}
		}
	}

	void OnEnable()
	{
		if ( mHighlightObjectInstance != null && !mWasUsed )
		{
			if ( PlayerController.s_PlayerController.GetView() == UsedBy )
			{
				mHighlightObjectInstance.SetActive( true );
			}
			
			else
			{
				mHighlightObjectInstance.SetActive( false );
			}
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
