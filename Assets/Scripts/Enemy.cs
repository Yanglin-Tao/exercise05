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

    public GameObject magicSparkle;

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
            Explode ();
            _audioSource.PlayOneShot(laughSound);
        }
    }

    void Explode () {
          GameObject magic = Instantiate(magicSparkle, transform.position, Quaternion.identity);
          magic.GetComponent<ParticleSystem>().Play();
    }

    IEnumerator ChasePlayer(){
        while (true){
            yield return new WaitForSeconds(3);
            _navMeshAgent.destination = player.transform.position;
        }
    }
}
