using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
            Invoke("loadOutside", 5);
        }
    }

    void loadOutside(){
        PublicVars.previousScene = "";
        SceneManager.LoadScene("Floor 0.5 Outside");
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
