using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueList : MonoBehaviour
{
    public FlagAssociaton[] _flagAssociations;

    void Start()
    {
        foreach (Transform child in transform.GetComponentInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        foreach (FlagAssociaton fa in _flagAssociations)
        {
            if (PublicVars.CheckFlag(fa._flag))
            {
                fa.EnableAssociatedObjs();
            }
        }
    }
}

[System.Serializable]
public class FlagAssociaton
{
    public PublicVars.Flag _flag;
    public GameObject[] _associatedObjs;

    public void EnableAssociatedObjs()
    {
        foreach (GameObject obj in _associatedObjs)
        {
            obj.SetActive(true);
        }
    }
}