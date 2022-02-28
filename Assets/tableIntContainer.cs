using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class tableIntContainer
{
    [HideInInspector]
    public List<int> rowsIndex;
    public List<rowBoardInt> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
            {
                rowsIndex = new List<int>();
                rows = new List<rowBoardInt>();
            }

            return rows.Count;
        }
    }

    public int getcell(int x, int y)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardInt>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardInt());
        }

        int index = rowsIndex.LastIndexOf(x);

        return rows[index].get(y);
    }
    public void setcell(int x, int y, int val)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardInt>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardInt());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].set(y, val);
    }
    public void addcell(int x, int y, int val)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardInt>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardInt());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].add(y, val);
    }
    public void remove(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardInt>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardInt());
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
            rows = new List<rowBoardInt>();
        }

        rowsIndex.Clear();
        rows.Clear();
    }

}

[System.Serializable]
public class rowBoardInt
{
    //public Dictionary<int, Cell> cols;

    [HideInInspector]
    public List<int> colsIndex;
    public List<int> cols;

    public int colCount
    {
        get
        {
            if (cols == null)
            {
                colsIndex = new List<int>();
                cols = new List<int>();
            }

            return cols.Count;
        }
    }

    public int get(int y)
    {

        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<int>();
        }

        if (!colsIndex.Contains(y))
            return -1;

        int index = colsIndex.LastIndexOf(y);
        return cols[index];
    }
    public void set(int y, int val)
    {

        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<int>();
        }

        if (!colsIndex.Contains(y))
            add(y, val);

        int index = colsIndex.LastIndexOf(y);
        cols[index] = val;
    }
    public void add(int y, int val)
    {
        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<int>();
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
            cols = new List<int>();
        }

        if (colsIndex.Contains(y))
        {

            int index = colsIndex.LastIndexOf(y);
            colsIndex.Remove(y);
            cols.Remove(cols[index]);
        }
    }
}