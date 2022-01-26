using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellClick : MonoBehaviour
{
    public Cell cell = null;

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
        arg[0] = cell.container.Get_idObj().ToString();

        ((actionBreakClick)cell.Actions["click"]).go(arg);
        //Debug.Log(cell.Actions["click"] + " : " + id.ToString() + " / " + cell.container.Get_idObj());
    }
}
