using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    NavMeshAgent _navMeshAgent;
    GameObject player;

    public AudioClip laughSound;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(ChasePlayer());

    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            _audioSource.PlayOneShot(laughSound);
        }
    }

    IEnumerator ChasePlayer(){
        while (true){
            yield return new WaitForSeconds(1);
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
