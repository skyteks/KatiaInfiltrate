using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public enum Sides
    {
        Left,
        Right,
    }
    [TextArea(3, 10)]
    public string sentence;
    public Sprite portrait;
    public Sides side;
}
