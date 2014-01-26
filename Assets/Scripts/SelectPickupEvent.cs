using UnityEngine;
using System.Collections;

public class SelectPickupEvent : GameEvent
{
	public Pickupable Item {get;set;}
	
	public SelectPickupEvent( Pickupable value )
	{
		Item = value;
	}
}