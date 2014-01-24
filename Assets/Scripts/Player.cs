using UnityEngine;
using System.Collections;
using Pathfinding;

public class Player : MonoBehaviour 
{
	public static Player s_Player;
	// Publics
	public Transform 	mTarget;
	public float		mSpeed = 1.0f;
	public float		mTargetDistance = 0.05f;

	// Privates
	private Seeker 		mSeeker;
	private Path		mPath;
	private int 		mCurrentWaypoint = 0;


	float mPathRecalculateTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		s_Player = this;
		mSeeker = GetComponent<Seeker>();

	}
	
	// Update is called once per frame
	void Update () 
	{	
		mPathRecalculateTimer += Time.deltaTime;
		if ( mPathRecalculateTimer >= 1.0f )
		{
			mPathRecalculateTimer = 0.0f;
			//mSeeker.StartPath( transform.position, mTarget.position, OnPathComplete );
		}
	}

	public void WalkTo( Vector3 vPosition )
	{
		mSeeker.StartPath( transform.position, vPosition, OnPathComplete );
	}

	public void OnPathComplete (Path p) 
	{
		mPath = p;
		mCurrentWaypoint = 0;
		Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
	}

	public void FixedUpdate () 
	{
		if ( mPath == null ) 
		{
			//We have no path to move after yet
			return;
		}
		
		if ( mCurrentWaypoint >= mPath.vectorPath.Count ) 
		{
			Debug.Log ("End Of Path Reached");
			mPath = null;
			return;
		}
		
		//Direction to the next waypoint
		Vector3 dir = ( mPath.vectorPath[ mCurrentWaypoint ] - transform.position ).normalized;
		dir *= mSpeed * Time.fixedDeltaTime;
		transform.position += dir;

		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if ( Vector3.Distance ( transform.position, mPath.vectorPath[ mCurrentWaypoint ] ) < mTargetDistance ) 
		{
			mCurrentWaypoint++;
			return;
		}
	}
}
