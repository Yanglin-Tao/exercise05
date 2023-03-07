using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource _audioSource;

	void Start()
	{
		if (GameObject.FindGameObjectsWithTag("Music Player").Length > 1)
		{
			Destroy(gameObject);
		}

		GameObject.DontDestroyOnLoad(gameObject);
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayNewSong(AudioClip song)
	{
		_audioSource.Stop();
		_audioSource.clip = song;
		_audioSource.Play();
	}

	public void StopPlaying()
	{
		_audioSource.Stop();
	}
}
