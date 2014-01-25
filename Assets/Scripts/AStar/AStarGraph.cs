using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarGraph : MonoBehaviour 
{
	public static List<AStarNode> s_Nodes = new List<AStarNode>();

	public static void AddNode( AStarNode pNode )
	{
		s_Nodes.Add( pNode );
	}

	static AStarNode GetClosestNode( Vector3 vPosition )
	{
		float fShortestDistance = float.MaxValue;
		AStarNode pClosestNode = null;
		foreach ( AStarNode node in s_Nodes )
		{
			float fDistance = Vector3.Distance( vPosition, node.transform.position );
			if ( pClosestNode == null || fDistance < fShortestDistance )
			{
				pClosestNode = node;
				fShortestDistance = fDistance;
			}
		}

		return pClosestNode;
	}

	class AStarNodeInfo
	{
		public AStarNode mNode;
		public AStarNodeInfo mPreviousNode;
		public float mCostG = float.MaxValue;
		public float mCostH = float.MaxValue;
		public float mCostF = float.MaxValue;
	}

	public static AStarPath GetPath( Vector3 vStartPosition, Vector3 vEndPosition )
	{
		AStarPath path = new AStarPath();
		AStarNode pStartNode = GetClosestNode( vStartPosition );
		AStarNode pEndNode = GetClosestNode( vEndPosition );
		Vector3 vEndNodePosition = pEndNode.transform.position;
		Dictionary< AStarNode, AStarNodeInfo > nodeInfos = new Dictionary<AStarNode, AStarNodeInfo>();
		List<AStarNodeInfo> openList = new List<AStarNodeInfo>();
		List<AStarNode> closedList = new List<AStarNode>();

		// Add start node to open list
		AddNodeToOpenList( pStartNode, null, nodeInfos, openList, closedList, vEndNodePosition );

		AStarNodeInfo pFinalNode = null;
		while ( openList.Count > 0 )
		{
			// Examine node
			AStarNodeInfo pCurrentNode = openList[ 0 ];
			openList.RemoveAt( 0 );

			if ( pCurrentNode.mNode == pEndNode )
			{
				pFinalNode = pCurrentNode;

				break;
			}

			else
			{
				foreach ( AStarNode pNode in pCurrentNode.mNode.Links )
				{
					AddNodeToOpenList( pNode, pCurrentNode, nodeInfos, openList, closedList, vEndNodePosition );
				}
			}
		}

		// Retrace path
		if ( pFinalNode != null )
		{
			AStarNodeInfo pNode = pFinalNode;
			while ( pNode != null )
			{
				path.InsertNode( pNode.mNode );
				pNode = pNode.mPreviousNode;
			}
		}

		return path;
	}

	static void AddNodeToOpenList( AStarNode pNode, AStarNodeInfo parent, Dictionary< AStarNode, AStarNodeInfo > nodeInfos, List<AStarNodeInfo> openList, List<AStarNode> closedList, Vector3 vEndPosition )
	{
		AStarNodeInfo info = null;
		if ( !nodeInfos.TryGetValue( pNode, out info ) )
		{
			info = new AStarNodeInfo();
			info.mNode = pNode;
			info.mCostH = Vector3.Distance( pNode.transform.position, vEndPosition );
		}

		float fGCost = 0.0f;
		if ( parent != null )
		{
			fGCost = parent.mCostG + Vector3.Distance( pNode.transform.position, parent.mNode.transform.position );
		}

		if ( fGCost < info.mCostG )
		{
			info.mPreviousNode = parent;
			info.mCostG = fGCost;
			info.mCostF = info.mCostG + info.mCostH;

			int iIndex = openList.Count;
			for ( int i = 0; i < iIndex; ++i )
			{
				if ( info.mCostF < openList[ i ].mCostF )
				{
					iIndex = i;
					break;
				}
			}

			openList.Remove( info );
			openList.Insert( iIndex, info );
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
