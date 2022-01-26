using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionFall : CellAction
{
    public new void Update()
    {
        //Debug.Log(cell.container.Get_idObj());

        if (cell.container.Get_idObj() == -1)
        {
            if (cell.up != null)
            {
                actionFall fall = ((actionFall)cell.up.Actions["Fall"]).callObj();

                //Debug.Log(fall);

                if (fall != null)
                {
                    cell.gameObject = fall.cell.gameObject;
                    cell.container.Set_idObj(fall.cell.container.Get_idObj());
                    
                    cell.gameObject.GetComponent<moveCell>().cell = cell;

                    fall.cell.gameObject = null;
                    fall.cell.container.Set_idObj(-1);
                }
            }
        }
    }
    public actionFall callObj()
    {
        if (cell.container.Get_idObj() == -1)
        {
            if (cell.up != null)
                return ((actionFall)cell.up.Actions["Fall"]).callObj();
            else
                return null;
        }
        else
        {
            return this;
        }
    }
}
