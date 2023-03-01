using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    public enum HorizDir { Left, Right };
    public enum VertDir { Forward, Backward };
    public enum Action { Standing, Moving }

    // External references
    public Transform _spriteQuad;
    MeshRenderer _spriteMesh;
    public Material _standingForwardMat;
    public Material _walkingForwardMat;
    public Material _standingBackwardMat;
    public Material _walkingBackwardMat;

    // Internal state
    HorizDir _horizDir;
    VertDir _vertDir;
    Action _action;


    void Start()
    {
        _spriteMesh = _spriteQuad.GetComponent<MeshRenderer>();
    }

    public void SetHorizontalDirection(HorizDir direction)
    {
        _horizDir = direction;

        switch (_horizDir)
        {
            case HorizDir.Left:
                _spriteQuad.localScale = new Vector3(1, _spriteQuad.localScale.y, _spriteQuad.localScale.z);
                break;
            case HorizDir.Right:
                _spriteQuad.localScale = new Vector3(-1, _spriteQuad.localScale.y, _spriteQuad.localScale.z);
                break;
        }
    }

    public void SetVerticalDirection(VertDir direction)
    {
        _vertDir = direction;
        UpdateSprite();
    }

    public void SetAction(Action action)
    {
        _action = action;
        UpdateSprite();
    }

    void UpdateSprite()
    {
        switch ((_vertDir, _action))
        {
            case (VertDir.Forward, Action.Standing):
                _spriteMesh.material = _standingForwardMat;
                break;
            case (VertDir.Forward, Action.Moving):
                _spriteMesh.material = _walkingForwardMat;
                break;
            case (VertDir.Backward, Action.Standing):
                _spriteMesh.material = _standingBackwardMat;
                break;
            case (VertDir.Backward, Action.Moving):
                _spriteMesh.material = _walkingBackwardMat;
                break;
        }
    }
}
