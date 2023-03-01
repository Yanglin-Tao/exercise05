using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trapdoor : MonoBehaviour
{   
    public bool locked = false;
    public string sceneToDropInto;
    public float sceneLoadTime = 2f;
    public float fallTimer;
    public Transform pivotPoint;
    public int rotateSpeed = 200;
    private float currentTimer;
    private bool playerFall;
    private bool falling = false;

    // Renderer used to show timer
    // Renderer renderer;
    void Start() {
        // Setting initial parameters
        currentTimer = fallTimer;
        playerFall = false;

        // Getting the render to show progression
        // renderer = GetComponent<Renderer>();
    }

    void Update() {
        // If the door is opening, rotate
        if(falling) {
            // Rotate about the pivot point
            transform.RotateAround(pivotPoint.position, Vector3.forward, -rotateSpeed * Time.deltaTime);
            // Stop rotating once we rotate 90 degrees
            if(transform.eulerAngles.z <= 270) {
                falling = false;
            }
        }
        
        // If the player is on the trapdoor, begin the timer
        if(!locked && playerFall) {
            // Update the timer
            currentTimer -= Time.deltaTime;

            // Update visuals
            // float ratio = currentTimer / fallTimer;
            // renderer.material.SetColor("_Color", new Color(1f - ratio, ratio, 0));

            // If the timer runs out, drop the player
            if(currentTimer <= 0f) {
                StartCoroutine(Drop());
            }
        }

        // TODO: Add code to unlock the trapdoor if necessary
        if(locked) {
            // Check if trapdoor can be unlocked
        }
    }

    IEnumerator Drop() {
        falling = true;
        yield return new WaitForSeconds(sceneLoadTime);
        SceneManager.LoadScene(sceneToDropInto);
    }


    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            playerFall = true;
        }
    }


    void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            playerFall = false;
            currentTimer = fallTimer;

            // Reset renderer color
            // renderer.material.SetColor("_Color", new Color(0f, 1f, 0f, 1f));
        }
    }
}
