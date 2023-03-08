using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
	public enum HorizDir { Left, Right };
	public enum Action { Standing, Moving }

	// External references
	public Transform _spriteQuad;
	MeshRenderer _spriteMesh;
	public Material _standingMat;
	public Material _walkingMat;
	public Material _standingBlinkingMat;
	public Material _walkingBlinkingMat;

	// Variables
	public float _walkingDuration;
	public float _blinkDuration;
	public float _blinkMinFreq;
	public float _blinkMaxFreq;

	// Internal state
	HorizDir _horizDir;
	Action _action;
	float _walkingTimer = 0;
	float _blinkingTimer = 5;
	bool _standing = false;
	bool _blinking = false;


	void Start()
	{
		_spriteMesh = _spriteQuad.GetComponent<MeshRenderer>();
	}

	public void SetHorizontalDirection(HorizDir direction)
	{
		_horizDir = direction;

		switch (_horizDir)
		{
			case HorizDir.Left:
				_spriteQuad.localScale = new Vector3(-1, _spriteQuad.localScale.y, _spriteQuad.localScale.z);
				break;
			case HorizDir.Right:
				_spriteQuad.localScale = new Vector3(1, _spriteQuad.localScale.y, _spriteQuad.localScale.z);
				break;
		}
	}

	public void SetAction(Action action)
	{
		_action = action;
		UpdateSprite();
	}

	void Update()
	{
		UpdateState();
		UpdateSprite();
	}

	void UpdateState()
	{
		// Blinking
		_blinkingTimer -= Time.unscaledDeltaTime;
		if (_blinkingTimer <= 0)
		{
			_blinking = !_blinking;
			if (!_blinking)
			{
				_blinkingTimer = Random.Range(_blinkMinFreq, _blinkMaxFreq);
			}
			else
			{
				_blinkingTimer = _blinkDuration;
			}
		}

		// Standing
		if (_action == Action.Standing)
		{
			_standing = true;
			return;
		}

		// Walking
		_walkingTimer -= Time.deltaTime;
		if (_walkingTimer <= 0)
		{
			_walkingTimer = _walkingDuration;
			_standing = !_standing;
		}
	}

	void UpdateSprite()
	{
		switch (_standing, _blinking)
		{
			case (true, false):
				_spriteMesh.material = _standingMat;
				break;
			case (true, true):
				_spriteMesh.material = _standingBlinkingMat;
				break;
			case (false, false):
				_spriteMesh.material = _walkingMat;
				break;
			case (false, true):
				_spriteMesh.material = _walkingBlinkingMat;
				break;
		}
	}
}
