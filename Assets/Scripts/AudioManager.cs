using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public AudioMixer _masterMixer;
	public string _parameter;
	Slider _slider;

	void Start()
	{
		_slider = GetComponent<Slider>();

		float v;
		_masterMixer.GetFloat(_parameter, out v);
		_slider.value = v;

		_slider.onValueChanged.AddListener(SetVolume);
	}

	public void SetVolume(float new_vol)
	{
		_masterMixer.SetFloat(_parameter, new_vol);
	}
}
