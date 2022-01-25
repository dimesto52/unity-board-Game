using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellClick : MonoBehaviour
{
    public Cell cell = null;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        string[] arg = new string[1];
        arg[0] = id.ToString();

        ((actionBreakClick)cell.Actions["click"]).go(arg);
        Debug.Log(cell.Actions["click"] + " : " + id.ToString());
    }
}
