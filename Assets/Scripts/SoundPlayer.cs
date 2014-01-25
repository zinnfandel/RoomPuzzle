using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioSource source;

	// Use this for initialization
	void Start () {
		Events.instance.AddListener<PlaySoundEvent>(OnPlaySound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnPlaySound(PlaySoundEvent e)
	{
		source.PlayOneShot(e.ClipToPlay);
	}
}