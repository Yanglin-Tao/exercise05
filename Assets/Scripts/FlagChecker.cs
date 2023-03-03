using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script will check that all flags in the _flagChecks list are set correctly. If they are, associated behaviors and
// renderers will be enabled, otherwise they will be disabled. You can also use CheckFlags() to see if the flags are set or not
// from other behaviors.

public class FlagChecker : MonoBehaviour
{
    public FlagCheck[] _flagChecks;
    public MonoBehaviour[] _controlledBehaviours;
    public Renderer[] _controlledRenderers;
    public Collider[] _controlledColliders;

    void Update()
    {
        // Enables the controlled behaviors when the flag checker returns true
        bool enable = CheckFlags();
        foreach (MonoBehaviour mb in _controlledBehaviours)
        {
            mb.enabled = enable;
        }
        foreach (Renderer re in _controlledRenderers)
        {
            re.enabled = enable;
        }

        foreach (Collider co in _controlledColliders)
        {
            co.enabled = enable;
        }
    }

    public bool CheckFlags()
    {
        bool passed = true;

        foreach (FlagCheck fc in _flagChecks)
        {
            passed = passed && fc.Check();
        }

        return passed;
    }
}

[System.Serializable]
public class FlagCheck
{
    public PublicVars.Flag _flag;
    public bool _enabled;

    public bool Check()
    {
        return PublicVars.CheckFlag(_flag) == _enabled;
    }
}