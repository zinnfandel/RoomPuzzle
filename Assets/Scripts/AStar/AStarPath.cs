using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarPath
{
	List<AStarNode> mNodes;
	public AStarPath()
	{
		mNodes = new List<AStarNode>();
	}

	public void InsertNode( AStarNode pNode )
	{
		mNodes.Insert( 0, pNode );
	}

	public AStarNode GetNode( int iIndex )
	{
		return mNodes[ iIndex ];
	}

	public int Count()
	{
		return mNodes.Count;
	}
}
