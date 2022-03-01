using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3CellClick : MonoBehaviour
{
    public cellLink cell
    {
        get
        {
            return this.GetComponent<cellLink>();
        }
    }
    public gemsSwap swap
    {
        get
        {
            return cell.board.GetComponent<gemsSwap>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (swap.mode == swapMode.secondSelect)
        {
            Vector3 realPos = swap.first.go.transform.position;
            Vector3 wantPos = swap.first.go.GetComponent<cellLink>().position;

            if (Vector3.Distance(realPos, wantPos) < 0.1f)
            {
                swap.testSwap();
                swap.mode = swapMode.noSelect;
                swap.first.go = null;
                swap.first.pos = Vector2.zero;
                swap.second.go = null;
                swap.second.pos = Vector2.zero;
            }
        }

        /*
        if (actionM3Click.second != null)
            if (actionM3Click.second.gameObject != null)
                if (moveCell.canmove && actionM3Click.second.position == actionM3Click.second.gameObject.transform.position)
                {
                    bool val1 = ((actionM3Kill)actionM3Click.first.Actions["kill"]).check();
                    bool val2 = ((actionM3Kill)actionM3Click.second.Actions["kill"]).check();

                    if ((!val1) && (!val2))
                    {
                        //Debug.Log("move not ok");
                        ((actionM3Click)cell.Actions["click"]).undo();
                    }
                    else
                    {
                        //Debug.Log("move ok");
                        ((actionM3Kill)actionM3Click.first.Actions["kill"]).Update();
                        ((actionM3Kill)actionM3Click.second.Actions["kill"]).Update();

                        actionM3Click.first = null;
                        actionM3Click.second = null;

                        if (m3BoardData.allowTurn > 0)
                            m3BoardData.allowTurn--;

                    }

                }
                */
    }

    private void OnMouseDown()
    {
        if (moveCell.canmove)
            if (swap.mode == swapMode.noSelect)
            {
                swap.first.go = this.gameObject;
                swap.first.pos = cell.pos;

                swap.mode = swapMode.firstSelect;
            }
            else if (swap.mode == swapMode.firstSelect)
            {

                swap.second.go = this.gameObject;
                swap.second.pos = cell.pos;

                swap.goSwap();

                swap.mode = swapMode.secondSelect;
            }

        /*
        if (m3BoardData.allowTurn > 0)
            if (moveCell.canmove && actionM3Click.second == null)
            {
                if (cell == actionM3Click.first)
                    actionM3Click.first = null;
                else
                {
                    string[] arg = new string[1];
                    arg[0] = "";

                    ((actionM3Click)cell.Actions["click"]).go(arg);
                }
            }
            */
    }
}
