using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoadDialogue : MonoBehaviour
{
    public PublicVars.Flag _disableFlag;
    public Dialogue[] _dialogue;
    public float _dialogueStartDelay = 2f;
    public PublicVars.Flag[] _flagsToSet;

    void Start()
    {
        if (PublicVars.CheckFlag(_disableFlag))
        {
            return;
        }

        Invoke("StartDialogue", _dialogueStartDelay);
    }

    void StartDialogue()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<DialogueManager>().AddDialogues(_dialogue);

        foreach (PublicVars.Flag flag in _flagsToSet)
        {
            PublicVars.SetFlag(flag);
        }
    }
}
