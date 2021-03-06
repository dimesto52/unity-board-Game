using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour
{

    public tableGameObjectContainer gocontainer;
    public tableIntContainer container;
    public boardShape obj;
    public boardValueInt initValue;

    public int alowMove;
    
    /*
    public Cell[] cells;

    public int height = 1;
    public int width = 1;
    */

    //public GameObject[] prefabCellContain;

    public void Start()
    {
        //if (cells.Length == 0)
        generate();

    }

    public void generate()
    {
        if (obj != null)
            if (obj.rows != null)
                foreach (int x in obj.rowsIndex)
                {
                    int indexX = obj.rowsIndex.IndexOf(x);
                    foreach (int y in obj.rows[indexX].cols)
                    {
                        int c = initValue.container.getcell(x, y);
                        container.addcell(x,y,c);
                    }
                }

        /*
        cells = new Cell[height * width];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                setCell(x, y, new Cell());
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
        */
    }
    /*
    public Cell getCell(int x , int y)
    {
        //return obj.getcell(x, y);

        return cells[x + y * width];
    }
    public void addCell(int x, int y)
    {
        if (obj == null)
            Debug.Log("no object");
        else
            obj.addcell(x, y);
    }
    public void setCell(int x , int y, Cell c)
    {
        cells[x + y * width] = c;
    }
    */
}
