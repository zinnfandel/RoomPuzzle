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

	void OnGui() 
	{
		if(!_selectionActive) return;

		GUI.Button(new Rect(10, 10, 150, 100), "Hello");
	}
}
