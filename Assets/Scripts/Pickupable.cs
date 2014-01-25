using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour 
{
	public static Pickupable s_CurrentPickup;

	public CharacterView PickedBy;
	public bool			InvisibleToOthers = false;

	bool	mWasPicked = false;


	// Use this for initialization
	void Start () 
	{
		mWasPicked = false;

		if ( InvisibleToOthers )
		{
			SpriteRenderer[] sprites = GetComponentsInChildren< SpriteRenderer >();
			foreach ( SpriteRenderer sprite in sprites )
			{
				Debug.Log( sprite.sortingLayerName );
				if ( PickedBy == CharacterView.Child && sprite.gameObject.layer != LayerMask.NameToLayer( "Kid" ) )
				{
					sprite.enabled = false;
				}

				else if ( PickedBy == CharacterView.Cat && sprite.gameObject.layer != LayerMask.NameToLayer( "Cat" ) )
				{
					sprite.enabled = false;
				}

				else if ( PickedBy == CharacterView.Grandma && sprite.gameObject.layer != LayerMask.NameToLayer( "Grandma" ) )
				{
					sprite.enabled = false;
				}
			}

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		Debug.Log ( "Pickupable clicked!" );


		//else
		{
			PlayerController.s_PlayerController.Pickup( this );
		}
	}

	public static void ClearCurrent()
	{
		s_CurrentPickup = null;
	}

	public static Pickupable GetCurrent()
	{
		return s_CurrentPickup;
	}

	public void Pickup()
	{
		if ( mWasPicked )
		{
			Debug.Log( "New focus item is set!" );
			s_CurrentPickup = this;
		}

		else if ( TableSpot.HasRoomOnTable() && mWasPicked == false && PlayerController.s_PlayerController.GetView() == PickedBy )
		{
			mWasPicked = true;
			transform.position = TableSpot.GetTableSpot();
			Debug.Log ( "Picked!" );

			SpriteRenderer[] sprites = GetComponentsInChildren< SpriteRenderer >();
			foreach ( SpriteRenderer sprite in sprites )
			{
				sprite.enabled = true;
			}
		}
	}
}
