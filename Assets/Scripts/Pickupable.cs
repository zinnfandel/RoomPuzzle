using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour 
{
	public CharacterView PickedBy;
	bool	mWasPicked = false;


	// Use this for initialization
	void Start () 
	{
		mWasPicked = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		Debug.Log ( "Pickupable clicked!" );
		PlayerController.s_PlayerController.Pickup( this );
	}

	public void Pickup()
	{
		if ( TableSpot.HasRoomOnTable() && mWasPicked == false && PlayerController.s_PlayerController.GetView() == PickedBy )
		{
			mWasPicked = true;
			transform.position = TableSpot.GetTableSpot();
			Debug.Log ( "Picked!" );
		}
	}
}
