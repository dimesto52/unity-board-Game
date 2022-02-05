using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3CellClick : MonoBehaviour
{
    public Cell cell
    {
        get
        {
            return this.GetComponent<cellLink>().cell;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            if (actionM3Click.second != null)
        if (actionM3Click.second.gameObject != null)
                if (moveCell.canmove && actionM3Click.second.position == actionM3Click.second.gameObject.transform.position)
        {
            bool val1 = ((actionM3Kill)actionM3Click.first.Actions["kill"]).check();
            bool val2 = ((actionM3Kill)actionM3Click.second.Actions["kill"]).check();

            if((!val1) &&(!val2))
            {
                ((actionM3Click)cell.Actions["click"]).undo();
            }
            else
            {
                    Debug.Log("move ok");
                ((actionM3Kill)actionM3Click.first.Actions["kill"]).Update();
                ((actionM3Kill)actionM3Click.second.Actions["kill"]).Update();

                actionM3Click.first = null;
                actionM3Click.second = null;

            }

        }

    }

    private void OnMouseDown()
    {

        if (moveCell.canmove && actionM3Click.second == null)
        {
            string[] arg = new string[1];
            arg[0] = "";
            
            ((actionM3Click)cell.Actions["click"]).go(arg);
        }
    }
}
