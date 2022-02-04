using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3CellClick : MonoBehaviour
{
    public Cell cell
    {
        get
        {
            return this.GetComponent<cellLink>().cell;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {

        if (moveCell.canmove)
        {
            string[] arg = new string[1];
            arg[0] = "";

            ((actionM3Click)cell.Actions["click"]).go(arg);
        }
    }
}
