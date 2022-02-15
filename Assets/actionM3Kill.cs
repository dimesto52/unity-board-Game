using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionM3Kill : CellAction
{

    // Update is called once per frame
    public new void Update()
    {
        //Debug.Log("kill");

        if (vertical >= 2 || horizontal >= 2)
        {
            int id = cell.container.Get_idObj();

            if (vertical >= 2)
            {

                //Debug.Log("vertical");

                up_break(id);
                down_break(id);
            }
            if (horizontal >= 2)
            {
                left_break(id);
                right_break(id);
            }

            kill();

            if (horizontal >= 4)
            {
                GameObject go = ((m3BoardData)cell.board).spawnBonus(id, cell, 0);
            }
            else if (vertical >= 4)
            {
                GameObject go = ((m3BoardData)cell.board).spawnBonus(id, cell, 1);
            }
            else if (vertical + horizontal >= 4)
            {
                GameObject go = ((m3BoardData)cell.board).spawnBonus(id, cell, 2);
            }

        }
    }
    public bool check()
    {
        return (vertical >= 2 || horizontal >= 2);
    }
    public void kill()
    {
        if (cell.gameObject != null)
            cell.gameObject.SendMessage("Onbreak");

        cell.container.Set_idObj(-1);
        cell.gameObject = null;
    }
    public void left_break(int id)
    {
        if (cell.left != null)
            if (cell.left.container.Get_idObj() == id)
            {
                actionM3Kill obj = ((actionM3Kill)cell.left.Actions["kill"]);
                obj.left_break(id);
                obj.kill();
            }
    }
    public void right_break(int id)
    {
        if (cell.right != null)
            if (cell.right.container.Get_idObj() == id)
            {
                actionM3Kill obj = ((actionM3Kill)cell.right.Actions["kill"]);
                obj.right_break(id);
                obj.kill();
            }
    }
    public void up_break(int id)
    {
        if (cell.up != null)
            if (cell.up.container.Get_idObj() == id)
            {
                actionM3Kill obj = ((actionM3Kill)cell.up.Actions["kill"]);
                obj.up_break(id);
                obj.kill();
            }
    }
    public void down_break(int id)
    {
        if (cell.down != null)
            if (cell.down.container.Get_idObj() == id)
            {
                actionM3Kill obj = ((actionM3Kill)cell.down.Actions["kill"]);
                obj.down_break(id);
                obj.kill();
            }
    }


    public int vertical
    {
        get
        {
            return up + down;
        }
    }
    public int horizontal
    {
        get
        {
            return left + right;
        }
    }
    public int up
    {
        get
        {
            int val = 0;
            if (cell.up != null)
                if (cell.container.Get_idObj() == cell.up.container.Get_idObj())
                {
                    val = 1;
                    val += ((actionM3Kill)cell.up.Actions["kill"]).up;
                }
            return val;
        }
    }
    public int down
    {
        get
        {
            int val = 0;

            if (cell.down != null)
                if (cell.container.Get_idObj() == cell.down.container.Get_idObj())
                {
                    val = 1;
                    val += ((actionM3Kill)cell.down.Actions["kill"]).down;
                }
            return val;
        }
    }
    public int left
    {
        get
        {
            int val = 0;

            if (cell.left != null)
                if (cell.container.Get_idObj() == cell.left.container.Get_idObj())
                {
                    val = 1;
                    val += ((actionM3Kill)cell.left.Actions["kill"]).left;
                }
            return val;
        }
    }
    public int right
    {
        get
        {
            int val = 0;

            if (cell.right != null)
                if (cell.container.Get_idObj() == cell.right.container.Get_idObj())
                {
                    val = 1;
                    val += ((actionM3Kill)cell.right.Actions["kill"]).right;
                }
            return val;
        }
    }
}
