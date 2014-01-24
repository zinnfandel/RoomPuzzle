using UnityEngine;
using System.Collections;

public class ViewSelectedEvent : GameEvent
{
	public CharacterView View {get;set;}

	public ViewSelectedEvent(CharacterView view)
	{
		View = view;
	}
}