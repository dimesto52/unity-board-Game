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

            int randid = Random.Range(0, base.prefabCellContain.Length);

            c.container.Set_idObj(randid);

            int row = index / height;
            int col = index % height;

            GameObject go = GameObject.Instantiate(base.prefabCellContain[randid]);
            go.transform.position = transform.position + Vector3.up * (row - height / 2.0f) + Vector3.right * (col - width / 2.0f);

            if (go.GetComponent<cellClick>() == null)
                go.AddComponent<cellClick>();

            go.GetComponent<cellClick>().id = randid;
            go.GetComponent<cellClick>().cell = c;

            c.gameObject = go;


           index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
