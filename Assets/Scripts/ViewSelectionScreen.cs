using UnityEngine;
using System.Collections;

public class ViewSelectionScreen : MonoBehaviour {

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

		if(GUI.Button(new Rect(10, 10, 150, 100), "Cat"))
		{
			//Cat selected!
			Events.instance.Raise(new ViewSelectedEvent(CharacterView.Cat));
			_selectionActive = false;
		}
	}
}
