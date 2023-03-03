using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    Animator _animator;


    void Start()
    {
        _animator = GetComponent<Animator>();

        string triggerName;

        switch (LevelTransitions.GetFadeIn())
        {
            case LevelTransitions.Transition.Regular:
                triggerName = "FadeInReg";
                break;
            case LevelTransitions.Transition.GoingUp:
                triggerName = "FadeInUp";
                break;
            case LevelTransitions.Transition.GoingDown:
                triggerName = "FadeInDown";
                break;
            default:
                triggerName = "None";
                break;
        }

        _animator.SetTrigger(triggerName);
    }

    public void TransitionOut(LevelTransitions.Transition transition)
    {
        string triggerName;

        switch (LevelTransitions.GetFadeIn())
        {
            case LevelTransitions.Transition.Regular:
                triggerName = "FadeOutReg";
                break;
            case LevelTransitions.Transition.GoingUp:
                triggerName = "FadeOutUp";
                break;
            case LevelTransitions.Transition.GoingDown:
                triggerName = "FadeOutDown";
                break;
            default:
                triggerName = "None";
                break;
        }

        _animator.SetTrigger(triggerName);
    }
}
