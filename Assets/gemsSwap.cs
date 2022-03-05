using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsSwap : MonoBehaviour
{

    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }
    gemM3Kill kill
    {
        get
        {
            return this.GetComponent<gemM3Kill>();
        }
    }

    public gemsSwaping first;
    public gemsSwaping second;

    public swapMode mode = swapMode.noSelect;

    public Sprite selectedSprite;
    public Sprite baseSprite;

    public void goSwap()
    {
        Vector2 pos1 = first.go.GetComponent<cellLink>().pos;
        Vector2 pos2 = second.go.GetComponent<cellLink>().pos;
        int val1 = board.container.getcell(pos1);
        int val2 = board.container.getcell(pos2);
        GameObject go1 = board.gocontainer.getcell(pos1);
        GameObject go2 = board.gocontainer.getcell(pos2);

        first.go.GetComponent<cellLink>().pos = pos2;
        second.go.GetComponent<cellLink>().pos = pos1;

        board.container.setcell(pos1, val2);
        board.container.setcell(pos2, val1);

        board.gocontainer.setcell(pos1, go2);
        board.gocontainer.setcell(pos2, go1);

        first.go.GetComponent<moveCell>().update = false;
        second.go.GetComponent<moveCell>().update = false;


    }


    void spawn(spawnEvent e)
    {
        e.go.AddComponent<m3CellClick>();
        //e.go.AddComponent<m3UpdateEndMove>();
    }

    void spawnBack(spawnBackEvent e)
    {
        e.go.AddComponent<selectBack>();
        e.go.GetComponent<selectBack>().selectedSprite = selectedSprite;
        e.go.GetComponent<selectBack>().baseSprite = baseSprite;
        e.go.GetComponent<selectBack>().pos = e.pos;
        e.go.GetComponent<selectBack>().swap = this;
        //e.go.AddComponent<m3UpdateEndMove>();
    }
    public void onSwapSelect(swapSelect e)
    {
        if (mode == swapMode.noSelect)
        {
            first.go = e.gameObject;
            first.pos = e.pos;

            mode = e.mode;
        }
        else if(mode == swapMode.firstSelect)
        {

            second.go = e.gameObject;
            second.pos = e.pos;

            goSwap();

            mode = e.mode;
        }
    }
    public void resetSwap()
    {
        mode = swapMode.noSelect;
        first.go = null;
        first.pos = Vector2.zero;
        second.go = null;
        second.pos = Vector2.zero;
    }
    public void testSwap()
    {
        if (first != null && second != null)
        {
            if (!(
                (kill.checkHorizontal(first.pos) >= 3) ||
                (kill.checkVertical(first.pos) >= 3) ||
                (kill.checkHorizontal(second.pos) >= 3) ||
                (kill.checkVertical(second.pos) >= 3)
                ))
                goSwap();
            else
            {

                board.alowMove--;

                board.SendMessage("killUpdate", first.pos, SendMessageOptions.DontRequireReceiver);
                board.SendMessage("killUpdate", second.pos, SendMessageOptions.DontRequireReceiver);

                /*
                first.go.GetComponent<moveCell>().update = true;
                second.go.GetComponent<moveCell>().update = true;
                */
            }
        }
    }
}

public enum swapMode
{
    noSelect,
    firstSelect,
    secondSelect
}


[System.Serializable]
public class gemsSwaping
{
    public GameObject go;
    public Vector2 pos;

    void spawn(spawnEvent e)
    {
        e.go.AddComponent<m3CellClick>();
    }

}
