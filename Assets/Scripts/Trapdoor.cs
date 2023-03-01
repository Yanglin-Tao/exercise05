using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{   
    public float fallTimer;
    private float currentTimer;
    private bool playerFall;

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
        // If the player is on the trapdoor, begin the timer
        if(playerFall) {
            // Update the timer
            currentTimer -= Time.deltaTime;

            // Update visuals
            // float ratio = currentTimer / fallTimer;
            // renderer.material.SetColor("_Color", new Color(1f - ratio, ratio, 0));

            // If the timer runs out, drop the player
            if(currentTimer <= 0f) {
                Destroy(gameObject);
            }
        }
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
