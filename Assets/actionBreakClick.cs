using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionBreakClick : CellAction
{

    public new void go(string[] arg)
    {
        int val = -1;
        //Debug.Log(val);
        int.TryParse(arg[0], out val);


        if (val == cell.container.Get_idObj())
        {

            //Debug.Log(cell.debugName);

                GameObject.Destroy(cell.gameObject);
                cell.container.Set_idObj(-1);
                cell.gameObject = null;

            if (cell.left != null)
            {
                ((actionBreakClick)cell.left.Actions["click"]).go(arg);
                //cell.left.right = null;
            }
            if (cell.right != null)
            {
                ((actionBreakClick)cell.right.Actions["click"]).go(arg);
                //cell.right.left = null;
            }
            if (cell.up != null)
            {
                ((actionBreakClick)cell.up.Actions["click"]).go(arg);
                //cell.up.down = null;
            }
            if (cell.down != null)
            {
                ((actionBreakClick)cell.down.Actions["click"]).go(arg);
                //cell.down.up = null;
            }
            
            /*
            cell.left = null;
            cell.right = null;
            cell.up = null;
            cell.down = null;
            */

        }

    }
}
