using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarNode : MonoBehaviour 
{
	public List<AStarNode> Links;

	// Use this for initialization
	void Start () 
	{
		AStarGraph.AddNode( this );
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.blue;
		foreach ( AStarNode node in Links )
		{		
			if ( node != null )
			{
				Gizmos.DrawLine( transform.position, node.transform.position );
			}
		}
	}
}
