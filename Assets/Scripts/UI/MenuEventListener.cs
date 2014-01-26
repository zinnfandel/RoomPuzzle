using UnityEngine;
using System.Collections;

public class MenuEventListener : MonoBehaviour 
{
	GameObject GameCamera;
	GameObject UICamera;
	// Use this for initialization
	void Start () 
	{
		GameCamera = GameObject.Find( "Main Camera" );
		UICamera = GameObject.Find( "GUI" );
		Events.instance.AddListener<SelectViewEvent>(OnSelectViewEvent);
		Events.instance.AddListener<ViewSelectedEvent>(OnViewSelectedEvent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSelectViewEvent(SelectViewEvent e)
	{
		GameCamera.GetComponent<Camera>().enabled = false;
		gameObject.SetActive( true );
	}

	void OnViewSelectedEvent(ViewSelectedEvent e)
	{
		Debug.Log( "Showing game camera" );
		GameCamera.GetComponent<Camera>().enabled = true;
		gameObject.SetActive( false );
	}
}
