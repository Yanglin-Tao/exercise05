using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    void Start()
    {
        Invoke("Poop", 3f);
        Invoke("SetDialogue", 7f);
    }

    void Poop()
    {
        PublicVars.SetFlag(PublicVars.Flag.DoorIsLocked);
    }

    void SetDialogue()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<DialogueManager>().AddDialogues(dialogue);
        PublicVars.SetFlag(PublicVars.Flag.FoundDoorKey);
    }
}
