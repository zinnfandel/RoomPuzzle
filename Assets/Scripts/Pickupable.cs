using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour 
{
	public CharacterView PickedBy;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if ( PlayerController.s_PlayerController.GetView() == PickedBy )
		{
			Debug.Log ( "Picked!" );
		}
	}
}
