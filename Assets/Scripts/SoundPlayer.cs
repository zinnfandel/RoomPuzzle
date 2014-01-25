using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] clips;

	// Use this for initialization
	void Start () {
		Events.instance.AddListener<PlaySoundEvent>(OnPlaySound);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnPlaySound(PlaySoundEvent e)
	{
		AudioClip selectedClip;
		switch(e.SoundToPlay)
		{
			case SoundLibrarySelection.Meow:
				selectedClip = clips[0];
				break;
			default:
				selectedClip = clips[0];
				break;
		}

		source.PlayOneShot(selectedClip);
	}
}