using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour
{
    public float _loadZoneDelay = 1;
    public LevelTransitions.Transition _fadeOut;
    public LevelTransitions.Transition _fadeIn;
    public string _levelToLoad;
    Collider _collider;
    TransitionManager _transitionManager;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _transitionManager = GameObject.FindGameObjectWithTag("Transition Manager").GetComponent<TransitionManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            LevelTransitions.SetFadeIn(_fadeIn);
            _transitionManager.TransitionOut(_fadeOut);
            Invoke("LoadLevel", _loadZoneDelay);
            _collider.enabled = false;
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
