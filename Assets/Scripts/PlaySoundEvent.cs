using UnityEngine;
using System.Collections;

public enum SoundLibrarySelection
{
	Meow
}

public class PlaySoundEvent : GameEvent {

	public SoundLibrarySelection SoundToPlay { get; set; }

	public PlaySoundEvent(SoundLibrarySelection theSound)
	{
		SoundToPlay = theSound;
	}
}
