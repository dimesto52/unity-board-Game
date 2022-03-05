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
                cell.board.SendMessage("testSwap",SendMessageOptions.DontRequireReceiver);
                cell.board.SendMessage("resetSwap", SendMessageOptions.DontRequireReceiver);
            }
        }

    }

    private void OnMouseDown()
    {
        if (moveCell.canmove)
            if (swap.mode == swapMode.noSelect)
            {
                cell.board.SendMessage(
                    "onSwapSelect",
                    new swapSelect(this.gameObject, cell.pos, swapMode.firstSelect),
                    SendMessageOptions.DontRequireReceiver);
            }
            else if (swap.mode == swapMode.firstSelect)
            {

                if (Vector2.Distance(swap.first.pos, cell.pos) <= 1.0f)
                {
                    cell.board.SendMessage(
                        "onSwapSelect",
                        new swapSelect(this.gameObject, cell.pos, swapMode.secondSelect),
                        SendMessageOptions.DontRequireReceiver);
                }
            }
    }
}

public class swapSelect
{
    public GameObject gameObject;
    public Vector2 pos;
    public swapMode mode;

    public swapSelect(GameObject gameObject,Vector2 pos,swapMode mode)
    {
        this.gameObject = gameObject;
        this.pos = pos;
        this.mode = mode;
    }

}
