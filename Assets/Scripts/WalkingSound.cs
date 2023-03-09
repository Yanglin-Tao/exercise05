using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingSound : MonoBehaviour
{
    public AudioClip walkingEffect;
    AudioSource _audioSource;
    NavMeshAgent _playerAgent;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = walkingEffect;
        _playerAgent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        // Check if the player is moving in any direction
        bool movingX = _playerAgent.velocity.x != 0;
        bool movingZ = _playerAgent.velocity.z != 0;
        
        // Play effect only if player is moving & not already playing
        if((movingX || movingZ) && !_audioSource.isPlaying) {
            _audioSource.Play();
        }
        else if(!movingX && !movingZ && _audioSource.isPlaying) { // Stop effect if it's already playing
            _audioSource.Stop();
        }
    }
}
