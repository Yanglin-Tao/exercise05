using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    CharacterRenderer _charRenderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _charRenderer = GetComponent<CharacterRenderer>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector3(horizontal, 0, vertical) * 3;
        UpdateSprite();
    }

    void UpdateSprite()
    {
        // Whether to use the walking sprite or the non-walking sprite
        if (_rigidbody.velocity.magnitude != 0)
        {
            _charRenderer.SetAction(CharacterRenderer.Action.Moving);
        }
        else
        {
            _charRenderer.SetAction(CharacterRenderer.Action.Standing);
        }

        if (_rigidbody.velocity.z > 0)
        {
            _charRenderer.SetVerticalDirection(CharacterRenderer.VertDir.Backward);
        }
        if (_rigidbody.velocity.z < 0)
        {
            _charRenderer.SetVerticalDirection(CharacterRenderer.VertDir.Forward);
        }

        if (_rigidbody.velocity.x > 0)
        {
            _charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Right);
        }
        if (_rigidbody.velocity.x < 0)
        {
            _charRenderer.SetHorizontalDirection(CharacterRenderer.HorizDir.Left);
        }
    }
}
