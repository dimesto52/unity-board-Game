using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BonusHBreak : m3BonusBreak
{

    public void doBreak()
    {
        //Debug.Log("doBreak");

        killLeft(cell.pos);
        killRight(cell.pos);
    }
    public void killLeft(Vector2 pos)
    {
        killDir(pos, Vector2.left);
    }
    public void killRight(Vector2 pos)
    {
        killDir(pos, Vector2.right);
    }
}
