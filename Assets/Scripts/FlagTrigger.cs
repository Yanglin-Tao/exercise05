using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// When the player steps into the associated trigger, the _flagToSet flag will be set, and if any dialogues are attached they
// will show up immediately as well. Use in association with FlagChecker to make this only happen when certain flags are already
// set, and/or to disable the trigger after it has set the associated flag

public class FlagTrigger : MonoBehaviour
{
    public PublicVars.Flag _flagToSet;
    public Dialogue[] _dialogues;
    DialogueManager _dialogueManager;

    void Start()
    {
        _dialogueManager = GameObject.FindWithTag("UI").GetComponent<DialogueManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PublicVars.SetFlag(_flagToSet);
            _dialogueManager.AddDialogues(_dialogues);
        }
    }
}
