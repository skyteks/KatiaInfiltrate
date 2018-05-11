using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject Asset/Dialogue", fileName = "new Dialogue")]
public class Conversation : ScriptableObject
{
    public bool loopLast;
    public Dialogue[] dialogues;
}
