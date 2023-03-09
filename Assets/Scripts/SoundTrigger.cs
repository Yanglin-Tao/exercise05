using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public FlagCheck[] _flagChecks;
    AudioSource _audioSource;
    public AudioClip enabledSound;
    public AudioClip disabledSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            // Check the flags
            bool enable = CheckFlags();

            // If enabled & valid
            if(enable && enabledSound != null) {
                _audioSource.PlayOneShot(enabledSound);
            }
            else if(!enable && disabledSound != null) { // If disabled & valid
                _audioSource.PlayOneShot(disabledSound);
            }
        }
    }

    bool CheckFlags() {
        // Check if all FlagChecks are true
        foreach (FlagCheck fc in _flagChecks)
        {
            if(!fc.Check()) return false;
        }
        return true;
    }
}