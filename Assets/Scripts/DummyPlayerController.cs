using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    public Transform _spriteTransform;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector3(horizontal, 0, vertical) * 3;
        if (horizontal < 0)
        {
            _spriteTransform.localScale = new Vector3(1, 0.5f, 1);
        }
        else if (horizontal > 0)
        {
            _spriteTransform.localScale = new Vector3(-1, 0.5f, 1);
        }
    }
}
