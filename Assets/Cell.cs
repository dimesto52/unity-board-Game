using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell
{

    public string debugName;
    public Vector3 position;

    public BoardData board;

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

    public void debug()
    {
        /*
        if(gameObject!=null)
            Debug.DrawLine(position, gameObject.transform.position, Color.green);*/

        if(down != null)
        {
            Debug.DrawLine(position, down.position, Color.red);
        }
    }

}
