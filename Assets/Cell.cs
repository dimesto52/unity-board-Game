using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell
{
    public Cell()
    {
        Actions = new Dictionary<string, CellAction>();
    }

    public CellContainer container;
    public Dictionary<string,CellAction> Actions;


    public Cell left = null;
    public Cell right = null;
    public Cell up = null;
    public Cell down = null;

    public GameObject gameObject;

}
