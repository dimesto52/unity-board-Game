using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour
{
    public Cell[] cells;

    public int height = 1;
    public int width = 1;

    public GameObject[] prefabCellContain;

    public void Start()
    {
        if (cells.Length == 0)
        generate();

    }
    public void generate()
    {
        cells = new Cell[height * width];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                setCell(x, y, new Cell());
                getCell(x, y).board = this;
                getCell(x, y).debugName = "("+x.ToString() + " : " + y.ToString()+")";
                if (x > 0)
                {
                    getCell(x, y).left = getCell((x - 1), y);
                    getCell((x - 1), y).right = getCell(x, y);
                }
                if (y > 0)
                {
                    getCell(x, y).down = getCell(x, (y - 1));
                    getCell(x, (y - 1)).up = getCell(x, y);
                }

            }

    }
    public Cell getCell(int x , int y)
    {
        return cells[x + y * width];
    }
    public void setCell(int x , int y, Cell c)
    {
        cells[x + y * width] = c;
    }
}
