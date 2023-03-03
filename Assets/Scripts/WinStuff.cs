using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStuff : MonoBehaviour
{
    float timer = 0;

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer < 0.5)
        {
            return;
        }

        LevelTransitions.SetFadeIn(LevelTransitions.Transition.NoTransition);
        GameObject.FindGameObjectWithTag("Transition Manager").GetComponent<TransitionManager>().TransitionOut(LevelTransitions.Transition.Regular);
        Invoke("LoadLevel", 1);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Win Screen");
    }
}
