using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "board", menuName = "board/boardObject", order = 1)]
public class boardObject : ScriptableObject
{

    //public Dictionary<int, rowBoardObject> rows;
    [HideInInspector]
    public List<int> rowsIndex;
    public List<rowBoardObject> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
            {
                rowsIndex = new List<int>();
                rows = new List<rowBoardObject>();
            }

            return rows.Count;
        }
    }

    public boardGemObject[] validObjectId;

    public Cell getcell(int x ,int y)
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        return rows[index].get(y);
    }
    public void addcell(int x ,int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].add(y);
        rows[index].get(y).boardO = this;
        rows[index].get(y).position = new Vector3(x,y);
    }
    public void remove(int x ,int y)
    {

        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardObject>();
        }

        if (!rowsIndex.Contains(x))
        {
            rowsIndex.Add(x);
            rows.Add(new rowBoardObject());
        }

        int index = rowsIndex.LastIndexOf(x);

        rows[index].remove(y);
    }
    public void clearCell()
    {
        if (rows == null)
        {
            rowsIndex = new List<int>();
            rows = new List<rowBoardObject>();
        }

        rowsIndex.Clear();
        rows.Clear();
    }

}

[System.Serializable]
public class rowBoardObject
{
    //public Dictionary<int, Cell> cols;

    [HideInInspector]
    public List<int> colsIndex;
    public List<Cell> cols;

    public int colCount
    {
        get
        {
            if (cols == null)
            {
                colsIndex = new List<int>();
                cols = new List<Cell>();
            }

            return cols.Count;
        }
    }

    public Cell get(int y)
    {

        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<Cell>();
        }

        if (!colsIndex.Contains(y))
            return null;

        int index = colsIndex.LastIndexOf(y);
        return cols[index];
    }
    public void add(int y)
    {
        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<Cell>();
        }

        if (!colsIndex.Contains(y))
        {
            colsIndex.Add(y);
            cols.Add(new Cell());
        }
    }
    public void remove(int y)
    {
        if (cols == null)
        {
            colsIndex = new List<int>();
            cols = new List<Cell>();
        }

        if (colsIndex.Contains(y))
        {

            int index = colsIndex.LastIndexOf(y);
            colsIndex.Remove(y);
            cols.Remove(cols[index]);
        }
    }
}
