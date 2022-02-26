using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "board", menuName = "board/boardObject", order = 1)]
public class boardObject : ScriptableObject
{

    public Dictionary<int, rowBoardObject> rows;

    public int rowCount
    {
        get
        {
            if (rows == null)
                rows = new Dictionary<int, rowBoardObject>();

            return rows.Count;
        }
    }

    public boardGemObject[] validObjectId;

    public Cell getcell(int x ,int y)
    {
        if (rows == null)
            rows = new Dictionary<int, rowBoardObject>();

        if (!rows.ContainsKey(x))
            rows.Add(x, new rowBoardObject());

        return rows[x].get(y);
    }
    public void addcell(int x ,int y)
    {

        if (rows == null)
            rows = new Dictionary<int, rowBoardObject>();

        if (!rows.ContainsKey(x))
            rows.Add(x, new rowBoardObject());

        rows[x].add(y);
        rows[x].get(y).boardO = this;
        rows[x].get(y).position = new Vector3(x,y);
    }
    public void remove(int x ,int y)
    {

        if (rows == null)
            rows = new Dictionary<int, rowBoardObject>();

        if (!rows.ContainsKey(x))
            rows.Add(x, new rowBoardObject());

        rows[x].remove(y);
    }
    public void clearCell()
    {
        if (rows == null)
            rows = new Dictionary<int, rowBoardObject>();

        rows.Clear();
    }

}

[System.Serializable]
public class rowBoardObject
{
    public Dictionary<int, Cell> cols;
    public int colCount
    {
        get
        {
            if (cols == null)
                cols = new Dictionary<int, Cell>();

            return cols.Count;
        }
    }

    public Cell get(int y)
    {

        if (cols == null)
            cols = new Dictionary<int, Cell>();

        if (!cols.ContainsKey(y))
            return null;

        return cols[y];
    }
    public void add(int y)
    {
        if (cols == null)
            cols = new Dictionary<int, Cell>();

        if (!cols.ContainsKey(y))
            cols.Add(y, new Cell());
    }
    public void remove(int y)
    {
        if (cols == null)
            cols = new Dictionary<int, Cell>();

        if (cols.ContainsKey(y))
            cols.Remove(y);
    }
}


[System.Serializable]
public class rowDictionary : SerializableDictionary<int, rowBoardObject> { }