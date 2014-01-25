using UnityEngine;
using System.Collections;

public class Usable : MonoBehaviour 
{
	public Pickupable UsedWith = null;
	public GameObject Reveals = null;
	public CharacterView UsedBy;
	public bool DisableAfterUse = false;
	// Use this for initialization
	void Start () 
	{
	
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
				if ( Reveals )
				{
					Reveals.SetActive( true );
				}

				if ( DisableAfterUse )
				{
					this.gameObject.SetActive( false );
				}
			}
		}
	}
}
