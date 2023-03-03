using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public string _mainMenuScene;

    public void LoadGame()
    {
        LevelTransitions.SetFadeIn(LevelTransitions.Transition.NoTransition);
        SceneManager.LoadScene(_mainMenuScene);
    }

    public void QuitGame()
    {
        print("Exiting game");
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }
}
