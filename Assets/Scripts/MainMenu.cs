using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string _startScene;

    public void LoadGame()
    {
        LevelTransitions.SetFadeIn(LevelTransitions.Transition.Regular);
        PublicVars.ResetAll();
        SceneManager.LoadScene(_startScene);
    }

    public void QuitGame()
    {
        print("Exiting game");
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }
}
