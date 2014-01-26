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
		GameCamera.SetActive( false );
		gameObject.SetActive( true );
	}

	void OnViewSelectedEvent(ViewSelectedEvent e)
	{
		Debug.Log( "Showing game camera" );
		GameCamera.SetActive( true );
		gameObject.SetActive( false );
	}
}
