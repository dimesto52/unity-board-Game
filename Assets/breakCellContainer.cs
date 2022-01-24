using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakCellContainer : CellContainer
{
    public int value;

    public void Set_idObj(int i)
    {
        value = i;
    }

    public int Get_idObj()
    {
        return value;
    }
}
