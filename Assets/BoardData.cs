using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour
{
    public Cell[] cells;

    public int height = 1;
    public int width = 1;

    public GameObject[] prefabCellContain;

    // Start is called before the first frame update
    public void Start()
    {
        cells = new Cell[height * width];
        /*
        for (int i = 0; i < cells.Length;i++)
        {
            cells[i] = new Cell();
        }
        */

        for(int x = 0; x<width; x++ )
            for(int y = 0; y<height;y++)
            {
                cells[x + y * width] = new Cell();
                if (x > 0)
                {
                    cells[x + y * width].left = cells[(x - 1) + y * width];
                    cells[(x - 1) + y * width].right = cells[x + y * width];
                }
                if (y > 0)
                {
                    cells[x + y * width].down = cells[x + (y - 1) * width];
                    cells[x + (y - 1) * width].up = cells[x + y * width];
                }

            }

    }

}
