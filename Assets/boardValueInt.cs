using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "board", menuName = "board/boardValueInt", order = 1)]
public class boardValueInt : ScriptableObject
{
    public tableIntContainer container = new tableIntContainer();
}
