using UnityEngine;
using System.Collections;

public class CharacterSelectionScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Events.instance.AddListener<SelectCharacterEvent>(OnSelectCharacterEvent);
	}

	private bool _selectionActive;

	void OnSelectCharacterEvent(SelectCharacterEvent e)
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
