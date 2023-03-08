using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
	public AudioClip music;

	void Update()
	{
		if (GameObject.FindGameObjectsWithTag("Music Player").Length > 1)
		{
			return;
		}

		GameObject.FindGameObjectWithTag("Music Player").GetComponent<MusicPlayer>().PlayNewSong(music);
		enabled = false;
	}
}
