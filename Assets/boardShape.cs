using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "board", menuName = "board/boardShape", order = 1)]
public class boardShape : ScriptableObject
{

    //public Dictionary<int, rowBoardObject> rows;
    [HideInInspector]
    public List<int> rowsIndex;
    public List<rowShape> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
            {
                rowsIndex = new List<int>();
                rows = new List<rowShape>();
            }

            return rows.Count;
        }
    }

    public bool getcell(int x, int y)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowShape>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowShape());
        }

        int index = rowsIndex.LastIndexOf(x);

        return rows[index].cols.Contains(y);
    }
    public void addcell(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowShape>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowShape());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].cols.Add(y);
    }
    public void remove(int x, int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowShape>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowShape());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].cols.Remove(y);
    }
    public void clearCell()
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowShape>();
        }

        rows.Clear();
    }

}

[System.Serializable]
public class rowShape
{
    public List<int> cols = new List<int>();
}

