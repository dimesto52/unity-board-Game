using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BonusVBreak : m3BonusBreak
{
    // Start is called before the first frame update

    public void doBreak()
    {
        //Debug.Log("doBreak");

        killUp(cell.pos);
        killUp(cell.pos);
    }
    public void killUp(Vector2 pos)
    {
        killDir(pos, Vector2.up);
    }
    public void killDown(Vector2 pos)
    {
        killDir(pos, Vector2.down);
    }
}
