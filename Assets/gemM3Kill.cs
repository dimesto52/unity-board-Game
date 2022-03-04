using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemM3Kill : MonoBehaviour
{

    public tableBoolContainer checkUpdate;


    public GameObject particul;
    public GameObject sound;


    void spawn(spawnEvent e)
    {

        e.go.AddComponent<onBreakPrefab>();
        e.go.GetComponent<onBreakPrefab>().particul = particul;
        e.go.GetComponent<onBreakPrefab>().sound = sound;
    }

    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }
    void Start()
    {
    }
    void Update()
    {
        if (moveCell.canmove)
        {
            if (checkUpdate != null)
                if (checkUpdate.rows != null)
                    foreach (int x in checkUpdate.rowsIndex)
                    {
                        int indexX = checkUpdate.rowsIndex.IndexOf(x);
                        foreach (int y in checkUpdate.rows[indexX].cols)
                        {
                            check(new Vector2(x, y));

                        }
                    }

            checkUpdate.clearCell();
        }
    }

    void killUpdate(Vector2 pos)
    {
        checkUpdate.addcell((int)pos.x, (int)pos.y);
    }
    public int check(Vector2 pos)
    {
        int res = 0;
        int id = board.container.getcell(pos);

        int h = checkHorizontal(pos);
        int v = checkVertical(pos);
        if (h >= 3|| v >= 3)
        {
            killobj(pos);
        }
        if (h >= 3)
        {
            res = h;
            killHorizontal(pos);
        }
        if (v >= 3)
        {
            res = v;
            killVertical(pos);
        }
        this.SendMessage("OnBonus", new onBonus(id, pos), SendMessageOptions.DontRequireReceiver);

        return res;
    }

    public void killobj(Vector2 pos)
    {
        
        GameObject go = board.gocontainer.getcell(pos);
        if (go != null)
            go.SendMessage("Onbreak");
            
    }
    public void killCross(Vector2 pos)
    {
        killLeft(pos);
        killRight(pos);
        killDown(pos);
        killUp(pos);

        killobj(pos);
    }
    public void killHorizontal(Vector2 pos)
    {
        killLeft(pos);
        killRight(pos);

        killobj(pos);
    }
    public void killVertical(Vector2 pos)
    {
        killDown(pos);
        killUp(pos);

        killobj(pos);
    }

    public void killDir(Vector2 pos, Vector2 Dir)
    {
        int i = board.container.getcell(pos);

        int check = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            Vector3 posCheck = pos + Dir * check;
            if (board.obj.getcell(posCheck))
            {
                int j = board.container.getcell(posCheck);
                if (i == j)
                {
                    killobj(posCheck);
                    //Debug.Log("check " + pos + " !");
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            check++;
        }
    }
    public void killLeft(Vector2 pos)
    {
        killDir(pos, Vector2.left);
    }
    public void killRight(Vector2 pos)
    {
        killDir(pos, Vector2.right);
    }
    public void killDown(Vector2 pos)
    {
        killDir(pos, Vector2.down);
    }
    public void killUp(Vector2 pos)
    {
        killDir(pos, Vector2.up);
    }

    public int checkHorizontal(Vector2 pos)
    {
        return 1 + checkLeft(pos) + checkRight(pos);
    }
    public int checkVertical(Vector2 pos)
    {
        return 1 + checkDown(pos) + checkUp(pos);
    }

    public int checkDir(Vector2 pos, Vector2 Dir)
    {
        int res = 0;

        int i = board.container.getcell(pos);

        int check = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            Vector3 posCheck = pos + Dir * check;
            if (board.obj.getcell(posCheck))
            {
                int j = board.container.getcell(posCheck);
                if (i == j)
                {
                    res++;
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            check++;
        }

        return res;
    }
    public int checkLeft(Vector2 pos)
    {
        return checkDir(pos, Vector2.left);
    }

    public int checkRight(Vector2 pos)
    {
        return checkDir(pos, Vector2.right);
    }

    public int checkDown(Vector2 pos)
    {
        return checkDir(pos, Vector2.down);
    }

    public int checkUp(Vector2 pos)
    {
        return checkDir(pos, Vector2.up);
    }

}
public class onBonus
{
    public int id;
    public Vector2 pos;

    public onBonus( int id, Vector2 pos)
    {
        this.id = id;
        this.pos = pos;
    }
    
}
