using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text _dialogueText;
    public Image _dialoguePortrait;
    UIManager _uiManager;
    Queue<Dialogue> _dialogueQ;

    void Start()
    {
        _dialogueQ = new Queue<Dialogue>();
        _uiManager = GetComponent<UIManager>();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (!IsDialogueOpen())
        {
            return;
        }

        if (_dialogueQ.Count > 0)
        {
            NextDialogue();
            return;
        }

        _uiManager.OnUnpause();
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

    void NextDialogue()
    {
        if (_dialogueQ.Count == 0) return;

        Dialogue next = _dialogueQ.Dequeue();
        _dialogueText.text = next._text;
        _dialoguePortrait.sprite = next._characterPortrait;

        if (!IsDialogueOpen())
        {
            _uiManager.OnDialogue();
        }
    }

    bool IsDialogueOpen()
    {
        return _uiManager.IsState(UIManager.UIState.InDialogue);
    }
}
