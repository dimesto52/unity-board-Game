using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakBoardData : BoardData
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        int index = 0;

        foreach (Cell c in base.cells)
        {
            c.container = new breakCellContainer();
            c.Actions.Add("click", new actionBreakClick());
            c.Actions["click"].cell = c;
            c.Actions.Add("Fall", new actionFall());
            c.Actions["Fall"].cell = c;

            int randid = Random.Range(0, base.prefabCellContain.Length);

            c.container.Set_idObj(randid);

            int row = index / height;
            int col = index % height;

            GameObject go = GameObject.Instantiate(base.prefabCellContain[randid]);
            go.transform.position = transform.position + Vector3.up * (row - height / 2.0f) + Vector3.right * (col - width / 2.0f);

            if (go.GetComponent<cellClick>() == null)
                go.AddComponent<cellClick>();
            
            go.GetComponent<cellClick>().cell = c;

            if (go.GetComponent<moveCell>() == null)
                go.AddComponent<moveCell>();

            go.GetComponent<moveCell>().cell = c;

            c.position = transform.position + Vector3.up * (row - height / 2.0f) + Vector3.right * (col - width / 2.0f);

            c.gameObject = go;


           index++;
        }
    }
    void Update()
    {

        foreach (Cell c in cells)
        {
            ((actionFall)c.Actions["Fall"]).Update();
        }
    }
}
