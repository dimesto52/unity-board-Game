using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class tableBoolContainer
{

    //public Dictionary<int, rowBoardObject> rows;
    [HideInInspector]
    public List<int> rowsIndex;
    public List<rowbool> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
            {
                rowsIndex = new List<int>();
                rows = new List<rowbool>();
            }

            return rows.Count;
        }
    }

    public bool getcell(int x, int y)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowbool>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowbool());
        }

        int index = rowsIndex.LastIndexOf(x);

        return rows[index].cols.Contains(y);
    }
    public void addcell(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowbool>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowbool());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].cols.Add(y);
    }
    public void remove(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowbool>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowbool());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].cols.Remove(y);
    }
    public void clearCell()
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowbool>();
        }

        rowsIndex.Clear();
        rows.Clear();
    }

}

[System.Serializable]
public class rowbool
{
    public List<int> cols = new List<int>();
}
