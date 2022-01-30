using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cell
{

    public string debugName;
    public Vector3 position;

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
        if(gameObject!=null)
            Debug.DrawLine(position, gameObject.transform.position, Color.green);

        if(container.Get_idObj() == -1)
        {
            Debug.DrawLine(position, position + Vector3.down, Color.red);
        }
    }

}
