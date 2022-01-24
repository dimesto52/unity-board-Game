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
        for (int i = 0; i < cells.Length;i++)
        {
            cells[i] = new Cell();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
