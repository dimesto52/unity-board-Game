using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3UpdateEndMove : MonoBehaviour
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

    bool doUpdate = false;

    // Update is called once per frame
    public void endMove()
    {
        doUpdate = true;
    }
    void FixedUpdate()
    {
        if (doUpdate && moveCell.canmove)
        {
            cell.board.SendMessage("testSwap");
        }
    }
}