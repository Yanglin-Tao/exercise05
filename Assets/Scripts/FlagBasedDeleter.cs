using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBasedDeleter : MonoBehaviour
{
    public PublicVars.Flag _deleteWhenSet;
    public GameObject[] _whatToDelete;

    void Update()
    {
        if (PublicVars.CheckFlag(_deleteWhenSet))
        {
            foreach (GameObject g in _whatToDelete)
            {
                Destroy(g);
            }
            Destroy(gameObject);
        }
    }
}
