using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDialogueTrigger : MonoBehaviour
{
    public Dialogue[] _dialogue;

    void Start()
    {
        Invoke("SetDialogue", 2f);
    }

    void SetDialogue()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<DialogueManager>().AddDialogues(_dialogue);
        PublicVars.SetFlag(PublicVars.Flag.DoorIsLocked);
    }
}
