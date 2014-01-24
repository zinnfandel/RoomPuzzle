using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Transform 	mTargetPosition;
	public Player		mPlayer;
	// Use this for initialization
	void Start () {
	
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
		}
	}

	void OnMouseDown() 
	{
	}
}
