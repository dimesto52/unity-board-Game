using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gemPatern", menuName = "board/gemPatern", order = 1)]
public class gemPatern : ScriptableObject
{
    public gemTreePaternTrunk trunk = new gemTreePaternTrunk();
    public List<gemTreePaternTrunk> subPaterne = new List<gemTreePaternTrunk>();
    public List<gemTreePaternLeaf> paternLeaf = new List<gemTreePaternLeaf>();

    public bool eval(BoardData data, Vector2 pos)
    {
        int id = data.container.getcell(pos);
        if (trunk.eval(data, this, pos, id) >= 1)
        {
            return true;
        }
        else
            return false;

    }

}

public interface gemTreePatern
{
    int getTypeTree();
    int eval(BoardData data, gemPatern patern, Vector2 pos, int id);
    int getMin();
    Vector2 getPosEditor();
    void SetPosEditor(Vector2 _pos);

}

[System.Serializable]
public class gemTreePaternTrunk : gemTreePatern
{
    public List<int> subPaterne = new List<int>();
    public gemTreeNext next = gemTreeNext.trunk;

    public int min = -1;
    public gemTreeOperation operation = gemTreeOperation.or;

    public int getTypeTree()
    {
        return 0;
    }
    public int getMin()
    {
        return min;
    }
    public Vector2 pos;
    public Vector2 getPosEditor()
    {
        return pos;
    }
    public void SetPosEditor(Vector2 _pos)
    {
        pos= _pos;
    }

    public gemTreePatern getNext(gemPatern patern,int i)
    {
        int curPatern = subPaterne[i];

        if (next == gemTreeNext.trunk)
        {
            return patern.subPaterne[curPatern];
        }
        else
        {
            return patern.paternLeaf[curPatern];
        }

    }
    public int eval(BoardData data, gemPatern patern, Vector2 pos, int id)
    {
                int sum = 0;
        switch(operation )
        {
            case gemTreeOperation.add:
                sum = 0;
                for(int i = 0; i< subPaterne.Count; i++)
                {
                    int temp = 0;
                    gemTreePatern sub = getNext(patern, i);
                    temp = sub.eval(data, patern, pos, id);
                    if (temp >= getMin())
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += temp;
                    }

                }

                break;

            case gemTreeOperation.or:
                sum = 0;
                for (int i = 0; i < subPaterne.Count; i++)
                {
                    gemTreePatern sub = getNext(patern, i);
                    if (sub.eval(data, patern, pos, id) >= sub.getMin())
                    {
                        sum = 1;
                    }
                }
                break;

            case gemTreeOperation.and:
                sum = 1;
                for (int i = 0; i < subPaterne.Count; i++)
                {
                    gemTreePatern sub = getNext(patern, i);
                    if (sub.eval(data, patern, pos, id) < sub.getMin())
                    {
                        sum = 0;
                    }
                }
                break;
        }

        return 0;
    }
    
}

public enum gemTreeOperation
{
    add,or,and
}
public enum gemTreeNext
{
    trunk,leaf
}

[System.Serializable]
public class gemTreePaternLeaf : gemTreePatern
{
    public List<Vector2> posPatern = new List<Vector2>();
    public bool repeat = false;
    public int min = -1;

    public int getMin()
    {
        return min;
    }
    public Vector2 pos;
    public Vector2 getPosEditor()
    {
        return pos;
    }
    public void SetPosEditor(Vector2 _pos)
    {
        pos = _pos;
    }

    public int eval(BoardData data, gemPatern patern, Vector2 pos, int id)
    {
        int res = 0;

        for (int ipos = 0; ipos < posPatern.Count; ipos++)
        {

            Vector2 curpose = posPatern[ipos];

            int iRepeat = 1;
            bool repeatPos = repeat;
            while (repeatPos)
            {
                Vector2 checkPos = (pos + curpose * iRepeat);
                if (data.obj.getcell(checkPos))
                {
                    if (data.container.getcell(checkPos) == id)
                    {
                        res++;
                    }
                }
            }
        }


        if (-1 != getMin())
            if (res >= getMin())
            {
                res = 1;
            }
            else
            {
                res = 0;
            }

        return res;
    }

    public int getTypeTree()
    {
        return 1;
    }
}