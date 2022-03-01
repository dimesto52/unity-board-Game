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

        if (h >= 3 && v >= 3)
        {
            res = h + v - 1;
            killCross(pos);
            this.SendMessage("OnBonus",new onBonus(res, id, pos, boardGemBonusType.cross), SendMessageOptions.DontRequireReceiver);
        }
        else if (h >= 3)
        {
            res = h;
            killHorizontal(pos);
            this.SendMessage("OnBonus", new onBonus(res, id, pos, boardGemBonusType.horizontal), SendMessageOptions.DontRequireReceiver);
        }
        else if (v >= 3)
        {
            res = v;
            killVertical(pos);
            this.SendMessage("OnBonus", new onBonus(res, id, pos, boardGemBonusType.vertical), SendMessageOptions.DontRequireReceiver);
        }

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

    public void killLeft(Vector2 pos)
    {
        int i = board.container.getcell(pos);

        int checkX = -1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell(pos + Vector2.right * checkX))
            {
                int j = board.container.getcell(pos + Vector2.right * checkX);
                if (i == j)
                {
                    killobj(pos + Vector2.right * checkX);
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkX--;
        }
    }
    public void killRight(Vector2 pos)
    {
        int i = board.container.getcell(pos);

        int checkX = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell(pos + Vector2.right * checkX))
            {
                int j = board.container.getcell(pos + Vector2.right * checkX);
                if (i == j)
                {
                    killobj(pos + Vector2.right * checkX);
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkX++;
        }
    }
    public void killDown(Vector2 pos)
    {
        int i = board.container.getcell(pos);

        int checkY = -1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell(pos + Vector2.up * checkY))
            {
                int j = board.container.getcell(pos + Vector2.up * checkY);
                if (i == j)
                {
                    killobj(pos + Vector2.up * checkY);
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkY--;
        }
    }
    public void killUp(Vector2 pos)
    {
        int i = board.container.getcell(pos);

        int checkY = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell(pos + Vector2.up * checkY))
            {
                int j = board.container.getcell(pos + Vector2.up * checkY);
                if (i == j)
                {
                    killobj(pos + Vector2.up * checkY);
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkY++;
        }
    }

    public int checkHorizontal(Vector2 pos)
    {
        return 1 + checkLeft(pos) + checkRight(pos);
    }
    public int checkVertical(Vector2 pos)
    {
        return 1 + checkDown(pos) + checkUp(pos);
    }
    public int checkLeft(Vector2 pos)
    {
        int res = 0;

        int i = board.container.getcell((int)pos.x, (int)pos.y);

        int checkX = -1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell((int)pos.x + checkX, (int)pos.y))
            {
                int j = board.container.getcell((int)pos.x + checkX, (int)pos.y);
                if (i == j)
                {
                    res++;
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkX--;
        }

        return res;
    }

    public int checkRight(Vector2 pos)
    {
        int res = 0;

        int i = board.container.getcell((int)pos.x, (int)pos.y);

        int checkX = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell((int)pos.x + checkX, (int)pos.y))
            {
                int j = board.container.getcell((int)pos.x + checkX, (int)pos.y);
                if (i == j)
                {
                    res++;
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkX++;
        }

        return res;
    }

    public int checkDown(Vector2 pos)
    {
        int res = 0;

        int i = board.container.getcell((int)pos.x, (int)pos.y);

        int checkY = -1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell((int)pos.x, (int)pos.y + checkY))
            {
                int j = board.container.getcell((int)pos.x, (int)pos.y + checkY);
                if (i == j)
                {
                    res++;
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkY--;
        }

        return res;
    }

    public int checkUp(Vector2 pos)
    {
        int res = 0;

        int i = board.container.getcell((int)pos.x, (int)pos.y);

        int checkY = 1;
        bool continuCheck = true;
        while (continuCheck)
        {
            if (board.obj.getcell((int)pos.x, (int)pos.y + checkY))
            {
                int j = board.container.getcell((int)pos.x, (int)pos.y + checkY);
                if (i == j)
                {
                    res++;
                }
                else
                    continuCheck = false;
            }
            else
                continuCheck = false;
            checkY++;
        }

        return res;
    }

}
public class onBonus
{
    public int val;
    public int id;
    public Vector2 pos;
    public boardGemBonusType mode;

    public onBonus(int val, int id, Vector2 pos, boardGemBonusType mode)
    {
        this.val = val;
        this.id = id;
        this.pos = pos;
        this.mode = mode;
    }
    
}
