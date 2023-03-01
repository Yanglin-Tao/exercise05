using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string _text;
    public Sprite _characterPortrait;

    public Dialogue(string text, Sprite portrait)
    {
        _text = text;
        _characterPortrait = portrait;
    }
}
