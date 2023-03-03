using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _unpausedUIObj; // Unpaused stuff
    public GameObject _journalUIObj; // Journal stuff
    public GameObject _exitUIObj; // Exit prompt stuff
    public GameObject _dialogueUIObj; // Dialogue box stuff

    // Internal state
    public enum UIState { Unpaused, Journal, ExitPrompt, InDialogue };
    UIState _state = UIState.Unpaused;

    void Start()
    {
        OnUnpause();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        switch (_state)
        {
            case UIState.InDialogue:
                break;

            case UIState.Journal:
                OnUnpause();
                break;

            case UIState.Unpaused:
            case UIState.ExitPrompt:
                OnOpenJournal();
                break;

            default:
                break;
        }
    }

    public void OnUnpause()
    {
        _state = UIState.Unpaused;
        Time.timeScale = 1;
        SetUIActivity();
    }

    public void OnOpenJournal()
    {
        _state = UIState.Journal;
        Time.timeScale = 0;
        SetUIActivity();
        PublicVars.ResetNewFlagCount();
    }

    public void OnExitPrompt()
    {
        _state = UIState.ExitPrompt;
        Time.timeScale = 0;
        SetUIActivity();
    }

    public void OnDialogue()
    {
        if (_state == UIState.ExitPrompt || _state == UIState.Journal || _state == UIState.InDialogue)
        {
            throw new InvalidOperationException("State must be UIState.Unpaused to call OnDialogue");
        }

        _state = UIState.InDialogue;
        Time.timeScale = 0;
        SetUIActivity();
    }

    void SetUIActivity()
    {
        _unpausedUIObj.SetActive(_state == UIState.Unpaused);
        _journalUIObj.SetActive(_state == UIState.Journal);
        _exitUIObj.SetActive(_state == UIState.ExitPrompt);
        _dialogueUIObj.SetActive(_state == UIState.InDialogue);
    }

    public void ExitGame()
    {
        print("Exiting game");
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }

    public bool IsState(UIState query_state)
    {
        return _state == query_state;
    }
}
