using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    Rigidbody _rigidbody;
    // CharacterRenderer _charRenderer;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mainCam = Camera.main;
        // float vertical = Input.GetAxisRaw("Vertical");
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // _rigidbody.velocity = new Vector3(horizontal, 0, vertical) * 3;
        // UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshAgent.destination = hit.point;
            }
        }
    }

//     void UpdateSprite()
//     {
//         // Whether to use the walking sprite or the non-walking sprite
//         if (_navMeshAgent.velocity.magnitude != 0)
//         {
//             _charRenderer.SetAction(CharacterRenderer.Action.Moving);
//         }
//         else
//         {
//             _charRenderer.SetAction(CharacterRenderer.Action.Standing);
//         }

//         if (_navMeshAgent.velocity.z > 0)
//         {
//             _charRenderer.SetVerticalDirection(CharacterRenderer.VertDir.Backward);
//         }
//         if (_navMeshAgent.velocity.z < 0)
//         {
//             _charRenderer.SetVerticalDirection(CharacterRenderer.VertDir.Forward);
//         }

//         if (_navMeshAgent.velocity.x > 0)
//         {
//             _charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Right);
//         }
//         if (_navMeshAgent.velocity.x < 0)
//         {
//             _charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Left);
//         }
//     }
}

