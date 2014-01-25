using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour 
{
	public Vector3 ScaleStart = new Vector3( 5, 5, 5 );
	public Vector3 ScaleEnd = new Vector3( 8, 8, 8 );
	public float ScaleTime = 1.0f;

	float mTimer = 0.0f;
	float mSign = 1.0f;

	// Use this for initialization
	void Start () 
	{
		mTimer = 0.0f;
		mSign = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTimer += Time.deltaTime * mSign;
		if ( mTimer >= ScaleTime )
		{
			mSign = -1.0f;
		}

		else if ( mTimer < 0 )
		{
			mSign = 1.0f;
		}

		transform.localScale = Vector3.Lerp( ScaleStart, ScaleEnd, mTimer / ScaleTime );
	}
}
