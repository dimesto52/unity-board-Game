using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "board", menuName = "board/boardObject", order = 1)]
public class boardObject : ScriptableObject
{
    public Cell[] nodes;
    public boardGemObject[] validObjectId;
}
