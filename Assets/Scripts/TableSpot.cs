using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableSpot : MonoBehaviour 
{
	static List<TableSpot> s_TableSpots = new List<TableSpot>();
	// Use this for initialization
	void Start () 
	{
		s_TableSpots.Add( this );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	static public bool HasRoomOnTable()
	{
		return ( s_TableSpots.Count > 0 ) ? true : false;
	}

	public static Vector3 GetTableSpot()
	{
		if ( s_TableSpots.Count == 0 )
		{
			//throw "No table spots available...";
		}

		Vector3 vPosition = s_TableSpots[ s_TableSpots.Count - 1 ].transform.position;
		s_TableSpots.RemoveAt( s_TableSpots.Count - 1 );

		return vPosition;
	}
}
