using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    void Start()
    {
        Invoke("SetDialogue", 5f);
    }

    void SetDialogue()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<DialogueManager>().AddDialogues(dialogue);
        PublicVars.SetFlag(PublicVars.Flag.FoundDoorKey);
    }
}
