using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionFall : CellAction
{
    public new void Update()
    {
        //Debug.Log(cell.container.Get_idObj());

        if (cell.container.Get_idObj() != -1)
        {
            Cell last = lastEmpty();

            if (last != null)
            if (last != cell)
            {
                //actionFall fall = ((actionFall)cell.up.Actions["Fall"]).callObj();

                //Debug.Log(fall);

                //if (cell.down.container.Get_idObj() == -1)
                //{

                GameObject go = cell.gameObject;

                last.gameObject = go;
                last.container.Set_idObj(cell.container.Get_idObj());

                    go.GetComponent<cellClick>().cell = last;
                    go.GetComponent<moveCell>().cell = last;

                    cell.gameObject = null;
                cell.container.Set_idObj(-1);

                //Debug.Log(last.gameObject);

                //}
            }
        }
    }
    public Cell lastEmpty()
    {
        Cell res = null;

        Cell last = cell;

        while (res == null && last != null)
        {
            if (last.down != null)
                if (last.down.container.Get_idObj() == -1)
                {
                    last = last.down;
                }
                else
                {
                    //Debug.Log(cell + " : " + last);
                    res = last;
                }
            else res = last;

        }

        return res;
    }
}
