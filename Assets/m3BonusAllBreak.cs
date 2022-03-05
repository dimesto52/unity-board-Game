using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BonusAllBreak : m3BonusBreak

{

    public void doBreak()
    {
        foreach (int x in cell.board.container.rowsIndex)
        {
            int indexX = cell.board.container.rowsIndex.IndexOf(x);
            foreach (int y in cell.board.container.rows[indexX].colsIndex)
            {
                killobj(new Vector2(x, y));
            }
        }
    }
}
