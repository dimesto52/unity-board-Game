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
            if (cell.down != null)
            {
                //actionFall fall = ((actionFall)cell.up.Actions["Fall"]).callObj();

                //Debug.Log(fall);

                if (cell.down.container.Get_idObj() == -1)
                {

                    cell.down.gameObject = cell.gameObject;
                    cell.down.container.Set_idObj(cell.container.Get_idObj());

                    cell.gameObject = null;
                    cell.container.Set_idObj(-1);
                    
                    cell.down.gameObject.GetComponent<moveCell>().cell = cell.down;
                    
                }
            }
        }
    }
}
