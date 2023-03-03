using System;
using System.Collections;
using System.Collections.Generic;

public static class LevelTransitions
{
    public enum Transition { GoingUp, GoingDown, Regular, NoTransition }

    static Transition FadeIn;

    static LevelTransitions()
    {
        FadeIn = Transition.NoTransition;
    }

    public static void SetFadeIn(Transition transition)
    {
        FadeIn = transition;
    }

    public static Transition GetFadeIn()
    {
        return FadeIn;
    }
}