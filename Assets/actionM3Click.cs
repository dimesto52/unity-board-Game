using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionM3Click : CellAction
{

    public static Cell first = null;
    public static Cell second = null;


    public new void go(string[] arg)
    {
        if(first == null)
        {
            first = base.cell;
            //Debug.Log(base.cell.debugName + " : " + 1);
        }
        else if(first.up == cell || first.down == cell || first.left == cell || first.right == cell)
        {
            //Debug.Log(actionM3Click.first);
            second = base.cell;
            swap();
        }
    }
    public void undo()
    {
        swap();
        first = null;
        second = null;
    }

    public void swap()
    {
        int firstId = first.container.Get_idObj();
        int secondId = second.container.Get_idObj();

        first.container.Set_idObj(secondId);
        second.container.Set_idObj(firstId);

        GameObject firstGameObject = first.gameObject;
        GameObject secondGameObject = second.gameObject;

        first.gameObject = secondGameObject;
        second.gameObject = firstGameObject;

        first.gameObject.GetComponent<cellLink>().cell = first;
        second.gameObject.GetComponent<cellLink>().cell = second;
    }
}
