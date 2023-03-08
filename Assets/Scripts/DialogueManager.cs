using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TMP_Text _dialogueText;
	public Image _dialoguePortrait;
	public GameObject _clickToContinueObj;
	public float _timeToSkipText = 0.35f;
	public float _secondsPerChar = 0.1f;
	UIManager _uiManager;
	AudioSource _audioSource;
	Queue<Dialogue> _dialogueQ;
	float _timeSinceTextStart;
	float _timeSinceLastChar;
	Dialogue _currentDialogue;
	int _placeInDialogue;

	void Start()
	{
		_dialogueQ = new Queue<Dialogue>();
		_uiManager = GetComponent<UIManager>();
		_audioSource = GetComponent<AudioSource>();
		_currentDialogue = null;
	}

	public void AddDialogue(Dialogue dialogue)
	{
		_dialogueQ.Enqueue(dialogue);
		NextDialogue();
	}

	public void AddDialogues(Dialogue[] dialogues)
	{
		foreach (Dialogue d in dialogues)
		{
			_dialogueQ.Enqueue(d);
		}
		NextDialogue();
	}

	public bool IsDialogueOpen()
	{
		return _uiManager.IsState(UIManager.UIState.InDialogue);
	}

	void NextDialogue()
	{
		if (_dialogueQ.Count == 0)
		{
			_uiManager.OnUnpause();
			return;
		}

		_currentDialogue = _dialogueQ.Dequeue();
		_timeSinceLastChar = 0;
		_timeSinceTextStart = 0;
		_placeInDialogue = 0;
		_dialogueText.text = "  ";
		_dialoguePortrait.sprite = _currentDialogue._characterPortrait;
		_clickToContinueObj.SetActive(false);

		if (!IsDialogueOpen())
		{
			_uiManager.OnDialogue();
		}
	}

	void Update()
	{
		if (IsDialogueOpen())
		{
			DisplayCharacters();
			ProcessInput();
			_clickToContinueObj.SetActive(_placeInDialogue >= _currentDialogue._text.Length);
		}
	}

	void DisplayCharacters()
	{
		if (_currentDialogue == null) return;

		_timeSinceLastChar += Time.unscaledDeltaTime;
		if (_timeSinceLastChar < _secondsPerChar) return;
		_timeSinceLastChar -= _secondsPerChar;

		if (_placeInDialogue < _currentDialogue._text.Length)
		{
			_placeInDialogue++;
			_dialogueText.text = _currentDialogue._text.Substring(0, _placeInDialogue);
			if (_placeInDialogue == _currentDialogue._text.Length)
			{
				_timeSinceTextStart = 0;
			}
		}
	}

	void ProcessInput()
	{
		_timeSinceTextStart += Time.unscaledDeltaTime;
		if (!Input.GetMouseButtonDown(0)) return;
		if (_timeSinceTextStart < _timeToSkipText) return;

		if (_placeInDialogue < _currentDialogue._text.Length)
		{
			_placeInDialogue = _currentDialogue._text.Length;
			_dialogueText.text = _currentDialogue._text;
			_timeSinceTextStart = 0;
		}
		else
		{
			_audioSource.Play();
			NextDialogue();
		}
	}
}
