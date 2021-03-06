using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BonusBreak : MonoBehaviour
{

    public cellLink cell
    {
        get
        {
            return this.GetComponent<cellLink>();
        }
    }
    

    public bool alreadyDestroy = false;

    private void Onbreak()
    {
        if (!alreadyDestroy)
        {
        //Debug.Log("booom !");
            alreadyDestroy = true;

            this.SendMessage("doBreak");
            //killobj(cell.pos);

            //doBreak();

        }
    }

    public void killobj(Vector2 pos)
    {

        GameObject go = cell.board.gocontainer.getcell(pos);
        if (go != null)
            go.SendMessage("Onbreak");

        //Debug.Log("kill " + pos + " !");

    }

    public void killDir(Vector2 pos, Vector2 Dir)
    {
        int i = cell.board.container.getcell(pos);

        int check = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (cell.board.obj.getcell(pos + Dir * check))
            {
                    killobj(pos + Dir * check);
                    //Debug.Log("check " + pos + " !");
            }
            else
                continuCheck = false;
            check++;
        }
    }
}

