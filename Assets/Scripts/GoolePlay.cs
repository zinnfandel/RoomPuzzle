using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GoolePlay : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		#if UNITY_ANDROID

		PlayGamesPlatform.Activate();

		#elif UNITY_IPHONE


		#else


		#endif


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
