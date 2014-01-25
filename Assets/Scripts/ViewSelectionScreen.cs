using UnityEngine;
using System.Collections;

public class ViewSelectionScreen : MonoBehaviour {

	public Texture2D GrandmaButton;
	public Texture2D ChildButton;
	public Texture2D CatButton;

	public Texture2D UnselectedCircle;
	public Texture2D SelectedCircle;

	public Texture2D BackgroundTexture;

	public GUIStyle guiStyle;

	// Use this for initialization
	void Start () {
		Events.instance.AddListener<SelectViewEvent>(OnSelectViewEvent);
	}

	private bool _selectionActive;

	void OnSelectViewEvent(SelectViewEvent e)
	{
		_selectionActive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		if(!_selectionActive) return;

		var margin = Screen.width/20;
		var thirdWidth = (Screen.width - 6*margin) / 3;
		var spriteWidth = thirdWidth / 2;
		var top = Screen.height * 0.6f;
		var spriteHeight = (Screen.height - top) / 2;

		var grandmaRect = new Rect(margin + spriteWidth/2, top, spriteWidth, spriteHeight);
		var childRect = new Rect(margin*3 + thirdWidth + spriteWidth/2, top, spriteWidth, spriteHeight);
		var catRect = new Rect(margin*5 + thirdWidth*2 + spriteWidth/2, top, spriteWidth, spriteHeight);

		var screenRect = new Rect(0, 0, Screen.width, Screen.height);
		GUI.DrawTexture(screenRect, BackgroundTexture, ScaleMode.ScaleToFit);

		if(grandmaRect.Contains(Event.current.mousePosition))
		{
			GUI.DrawTexture(grandmaRect, SelectedCircle, ScaleMode.ScaleToFit);
		}
		else 
		{
			GUI.DrawTexture(grandmaRect, UnselectedCircle, ScaleMode.ScaleToFit);
		}

		if(childRect.Contains(Event.current.mousePosition))
		{
			GUI.DrawTexture(childRect, SelectedCircle, ScaleMode.ScaleToFit);
		}
		else 
		{
			GUI.DrawTexture(childRect, UnselectedCircle, ScaleMode.ScaleToFit);
		}

		if(catRect.Contains(Event.current.mousePosition))
		{
			GUI.DrawTexture(catRect, SelectedCircle, ScaleMode.ScaleToFit);
		}
		else 
		{
			GUI.DrawTexture(catRect, UnselectedCircle, ScaleMode.ScaleToFit);
		}

		GUI.DrawTexture(grandmaRect, GrandmaButton, ScaleMode.ScaleToFit);
		GUI.DrawTexture(childRect, ChildButton, ScaleMode.ScaleToFit);
		GUI.DrawTexture(catRect, CatButton, ScaleMode.ScaleToFit);


		if(Event.current.type == EventType.MouseUp)
		{
			if(grandmaRect.Contains(Event.current.mousePosition))
			{
				Events.instance.Raise(new ViewSelectedEvent(CharacterView.Grandma));
				_selectionActive = false;
				return;
			}

			if(childRect.Contains(Event.current.mousePosition))
			{
				Events.instance.Raise(new ViewSelectedEvent(CharacterView.Child));
				_selectionActive = false;
				return;
			}

			if(catRect.Contains(Event.current.mousePosition))
			{
				Events.instance.Raise(new ViewSelectedEvent(CharacterView.Cat));
				_selectionActive = false;
				return;
			}
		}
	}
}
