using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public static Player s_Player;
	// Publics
	public Transform 	mTarget;
	public float		mSpeed = 1.0f;
	public float		mTargetDistance = 0.05f;

	// Privates
	private AStarPath	mPath;
	private int 		mCurrentWaypoint = 0;

	public Vector2 movingDirection;

	float mPathRecalculateTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		movingDirection = Vector2.zero;
		s_Player = this;

	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	public bool IsWalking()
	{
		if ( mPath != null )
			return true;

		return false;
	}

	public void WalkTo( Vector3 vPosition )
	{
		mPath = AStarGraph.GetPath( transform.position, vPosition );
		mCurrentWaypoint = 0;
		Debug.Log( mPath.Count() );
	}

	public void FixedUpdate () 
	{
		if ( mPath == null ) 
		{
			//We have no path to move after yet
			return;
		}
		
		if ( mCurrentWaypoint >= mPath.Count() ) 
		{
			Debug.Log ("End Of Path Reached");
			mPath = null;

			movingDirection = Vector2.zero;

			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = ( mPath.GetNode( mCurrentWaypoint ).transform.position - transform.position ).normalized;

		movingDirection = dir;

		dir *= mSpeed * Time.fixedDeltaTime;
		transform.position += dir;

		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if ( Vector3.Distance ( transform.position, mPath.GetNode( mCurrentWaypoint ).transform.position ) < mTargetDistance ) 
		{
			mCurrentWaypoint++;
			return;
		}
	}
}
