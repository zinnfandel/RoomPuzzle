using UnityEngine;
using System.Collections;

public class PlaySoundEvent : GameEvent {

	public AudioClip ClipToPlay { get; set; }

	public PlaySoundEvent(AudioClip theClip)
	{
		ClipToPlay = theClip;
	}
}
