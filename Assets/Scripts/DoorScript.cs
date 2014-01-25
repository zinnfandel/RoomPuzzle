using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
	public PlayerController mPlayerController;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D( Collider2D collision )
	{
		Events.instance.Raise(new SelectViewEvent());
	}

	void OnTriggerExit2D( Collider2D collision )
	{
	}

	void OnMouseDown()
	{
	}


}
