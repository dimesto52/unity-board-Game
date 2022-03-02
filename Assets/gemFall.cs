using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemFall : MonoBehaviour
{
    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (board.obj != null)
            if (board.obj.rows != null)
                foreach (int x in board.obj.rowsIndex)
                {
                    int indexX = board.obj.rowsIndex.IndexOf(x);
                    foreach (int y in board.obj.rows[indexX].cols)
                    {
                        int c = board.container.getcell(x, y);
                        if (c != -1)
                            testFall(x, y);
                    }
                }
    }
    void testFall(int x, int y)
    {
        bool spaceDown = board.obj.getcell(x, y-1);
        if (spaceDown)
        {
            int downVal = board.container.getcell(x, y - 1);

            if (downVal == -1)
            {
                Fall(x, y-1);

            }
        }
    }

    void Fall(int x, int y)
    {
        GameObject go = board.gocontainer.getcell(x, y+1);
        
        if (go != null)
        {
            Vector2 FallPos = mostDownPos(new Vector2(x, y));

            go.GetComponent<cellLink>().pos = FallPos;
            

            board.gocontainer.setcell(x, y + 1, null);
            board.gocontainer.setcell(FallPos, go);


            int val = board.container.getcell(x, y + 1);
            board.container.setcell(x, y + 1, -1);
            board.container.setcell(FallPos, val);
        }
    }


    public float speed = 2.0f;
    void spawn(spawnEvent e)
    {
        e.go.AddComponent<moveCell>();
        e.go.GetComponent<moveCell>().speed = speed;
    }

    Vector2 mostDownPos(Vector2 pos)
    {
        int i = 0;
        bool ContinueDown = true;

        while (ContinueDown)
        {
            Vector2 checkPos = pos + i * Vector2.down;
            if (board.obj.getcell(checkPos))
            {
                if (board.container.getcell(checkPos) == -1)
                {
                    i++;
                }
                else
                    ContinueDown = false;
            }
            else
                ContinueDown = false;
        }

        return pos + (i - 1) * Vector2.down;
    }
}
