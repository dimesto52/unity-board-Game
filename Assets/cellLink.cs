using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellLink : MonoBehaviour
{
    //public Cell cell = null;

    public Vector2 pos;
    public BoardData board;

    public int value = -1;

    public Vector3 position
    {
        get
        {
            return board.transform.position + (Vector3)pos;
        }
    }

    void Update()
    {
        value = board.container.getcell((int)pos.x, (int)pos.y);

    }
}
