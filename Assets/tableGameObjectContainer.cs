using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class tableGameObjectContainer
{
    [HideInInspector]
    public List<int> rowsIndex;
    public List<rowBoardGameObject> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
            {
                rowsIndex = new List<int>();
                rows = new List<rowBoardGameObject>();
            }

            return rows.Count;
        }
    }

    public GameObject getcell(Vector2 pos)
    {
        return getcell((int)pos.x, (int)pos.y);
    }
    public GameObject getcell(int x, int y)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardGameObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardGameObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        return rows[index].get(y);
    }
    public void setcell(Vector2 pos, GameObject val)
    {
        setcell((int)pos.x, (int)pos.y, val);
    }
    public void setcell(int x, int y, GameObject val)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardGameObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardGameObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].set(y, val);
    }
    public void addcell(int x, int y, GameObject val)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardGameObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardGameObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].add(y, val);
    }
    public void remove(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardGameObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardGameObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].remove(y);

        if (rows[index].cols.Count == 0)
        {
            rowsIndex.Remove(x);
            rows.Remove(rows[index]);
        }

    }
    public void clearCell()
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardGameObject>();
        }

        rowsIndex.Clear();
        rows.Clear();
    }

}

[System.Serializable]
public class rowBoardGameObject
{
    //public Dictionary<int, Cell> cols;

    [HideInInspector]
    public List<int> colsIndex;
    public List<GameObject> cols;

    public int colCount
    {
        get
        {
            if (cols == null)
            {
                colsIndex = new List<int>();
                cols = new List<GameObject>();
            }

            return cols.Count;
        }
    }

    public GameObject get(int y)
    {

        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<GameObject>();
        }

        if (!colsIndex.Contains(y))
            return null;

        int index = colsIndex.LastIndexOf(y);
        return cols[index];
    }
    public void set(int y, GameObject val)
    {

        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<GameObject>();
        }

        if (!colsIndex.Contains(y))
            add(y, val);

        int index = colsIndex.LastIndexOf(y);
        cols[index] = val;
    }
    public void add(int y, GameObject val)
    {
        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<GameObject>();
        }

        if (!colsIndex.Contains(y))
        {
            colsIndex.Add(y);
            cols.Add(val);
        }
    }
    public void remove(int y)
    {
        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<GameObject>();
        }

        if (colsIndex.Contains(y))
        {

            int index = colsIndex.LastIndexOf(y);
            colsIndex.Remove(y);
            cols.Remove(cols[index]);
        }
    }
}