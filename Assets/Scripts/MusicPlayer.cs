using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource _audioSource;
	AudioClip _currentClip;

	void Start()
	{
		if (GameObject.FindGameObjectsWithTag("Music Player").Length != 1)
		{
			Destroy(gameObject);
		}

		GameObject.DontDestroyOnLoad(gameObject);
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlayNewSong(AudioClip song)
	{
		if (!SameClip(song))
		{
			_audioSource.Stop();
			_audioSource.clip = song;
			_audioSource.Play();
			_currentClip = song;
		}
	}

	public void StopPlaying()
	{
		_audioSource.Stop();
	}

	bool SameClip(AudioClip clip)
	{
		return (clip == _currentClip);
	}
}
