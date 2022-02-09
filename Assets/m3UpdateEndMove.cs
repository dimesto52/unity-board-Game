using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3UpdateEndMove : MonoBehaviour
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

    bool doUpdate = false;

    // Update is called once per frame
    public void endMove()
    {
        doUpdate = true;
    }
    void FixedUpdate()
    {
        if (doUpdate && moveCell.canmove && cell != actionM3Click.first && cell != actionM3Click.second)
        {
            ((actionM3Kill)cell.Actions["kill"]).Update();
        }
    }
}