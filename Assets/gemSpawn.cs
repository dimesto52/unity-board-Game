using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardData))]
public class gemSpawn : MonoBehaviour
{
    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }

    GameObject gemContainer;
    public GameObject Container
    {
        get
        {
            return gemContainer;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        gemContainer = new GameObject();
        gemContainer.name = "gemContainer";
        gemContainer.transform.position = transform.position;
        gemContainer.transform.parent = transform;

        if (board.obj != null)
            if (board.obj.rows != null)
                foreach (int x in board.obj.rowsIndex)
                {
                    int indexX = board.obj.rowsIndex.IndexOf(x);
                    foreach (int y in board.obj.rows[indexX].cols)
                    {
                        int c = board.initValue.container.getcell(x, y);
                        if (c != -1)
                            spawnAt(new Vector2(x, y), c);
                    }
                }
    }

    public boardShape spawner;

    public List<GameObject> gems;
    public List<GameObject> gemsSpawn;

    public float timeLeft = 0;
    public float speedStep = 2.0f;
    public float waitStep = 0.05f;

    void Update()
    {
        timeLeft += Time.deltaTime * speedStep;

        //if (allowTurn > 0)
        if (timeLeft >= 1.0f + waitStep)
        {
            timeLeft -= 1.0f + waitStep;

            //paterne spawn
            if (spawner != null)
                if (spawner.rows != null)
                    foreach (int x in spawner.rowsIndex)
                    {
                        int indexX = spawner.rowsIndex.IndexOf(x);
                        foreach (int y in spawner.rows[indexX].cols)
                        {
                            int c = board.container.getcell(x, y);

                            if (c == -1)
                            {
                                Vector2 pos = new Vector2(x, y);
                                pos = mostDownPos(pos);
                                int[] valid = gemValid(pos);
                                int rand = Random.Range(0, valid.Length);

                                c = valid[rand];
                                spawnAt(new Vector2(x, y), c);
                            }
                        }
                    }
        }
    }

    int[] gemValid(Vector2 pos)
    {
        Vector2 down =  mostDownPos(pos);

        List<int> inValidh = gemInValidH(down);
        List<int> inValidv = gemInValidV(down);

        List<int> res = new List<int>(); 

        for(int i = 0; i < gemsSpawn.Count; i++)
        {
            if(!(inValidh.Contains(i) || inValidv.Contains(i)))
            {
                res.Add(i);
            }
        }

        return res.ToArray();
    }
    Vector2 mostDownPos(Vector2 pos)
    {
        int i = 0;
        bool ContinueDown = true;

        while(ContinueDown)
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
    List<int> gemInValidH(Vector2 pos)
    {
        List<int> res = new List<int>();

        Vector2 posm2 = pos + Vector2.right * -2;
        Vector2 posm1 = pos + Vector2.right * -1;
        Vector2 posp1 = pos + Vector2.right * 1;
        Vector2 posp2 = pos + Vector2.right * 2;

        int m2 = -1;
        int m1 = -1;
        int p1 = -1;
        int p2 = -1;

        if (board.obj.getcell(posm2)) m2 = board.container.getcell(posm2);
        if (board.obj.getcell(posm1)) m1 = board.container.getcell(posm1);
        if (board.obj.getcell(posp1)) p1 = board.container.getcell(posp1);
        if (board.obj.getcell(posp2)) p2 = board.container.getcell(posp2);

        if (m2 != -1)
        {
            if (m1 != -1)
            {
                if (m1 == m2)
                    if (!res.Contains(m1))
                        res.Add(m1);
            }
        }
        if (m1 != -1)
        {
            if (p1 != -1)
            {
                if (m1 == p1)
                    if (!res.Contains(p1))
                        res.Add(p1);
            }
        }
        if (p1 != -1)
        {
            if (p2 != -1)
            {
                if (p1 == p2)
                    if (!res.Contains(p2))
                        res.Add(p2);
            }
        }

        return res;
    }
    List<int> gemInValidV(Vector2 pos)
    {
        List<int> res = new List<int>();

        Vector2 posm2 = pos + Vector2.up * -2;
        Vector2 posm1 = pos + Vector2.up * -1;
        Vector2 posp1 = pos + Vector2.up * 1;
        Vector2 posp2 = pos + Vector2.up * 2;

        int m2 = -1;
        int m1 = -1;
        int p1 = -1;
        int p2 = -1;

        if (board.obj.getcell(posm2)) m2 = board.container.getcell(posm2);
        if (board.obj.getcell(posm1)) m1 = board.container.getcell(posm1);
        if (board.obj.getcell(posp1)) p1 = board.container.getcell(posp1);
        if (board.obj.getcell(posp2)) p2 = board.container.getcell(posp2);

        if (m2 != -1)
        {
            if (m1 != -1)
            {
                if (m1 == m2)
                    if (!res.Contains(m1))
                        res.Add(m1);
            }
        }
        if (m1 != -1)
        {
            if (p1 != -1)
            {
                if (m1 == p1)
                    if (!res.Contains(p1))
                        res.Add(p1);
            }
        }
        if (p1 != -1)
        {
            if (p2 != -1)
            {
                if (p1 == p2)
                    if (!res.Contains(p2))
                        res.Add(p2);
            }
        }

        return res ;
    }

    void spawnAt(Vector2 pos, int id)
    {
        GameObject go;
        if (id >= this.gems.Count)
            go = GameObject.Instantiate(this.gemsSpawn[id]);
        else
            go = GameObject.Instantiate(this.gems[id - this.gems.Count]);

        go.transform.position = transform.position + new Vector3(pos.x, pos.y, -1);
        go.transform.parent = gemContainer.transform;

        Vector2 dpos = mostDownPos(pos);

        board.container.setcell((int)dpos.x, (int)dpos.y, id);
        board.gocontainer.setcell((int)dpos.x, (int)dpos.y, go);

        this.gameObject.SendMessage("spawn", new spawnEvent(dpos, go), SendMessageOptions.DontRequireReceiver);
    }

    public float speedIncrease = 2.0f;
    void spawn(spawnEvent e)
    {

        e.go.AddComponent<cellLink>();
        e.go.GetComponent<cellLink>().board = board;
        e.go.GetComponent<cellLink>().pos = e.pos;

        e.go.AddComponent<increaseInStart>();
        e.go.GetComponent<increaseInStart>().speed = speedIncrease;
    }
}

public class spawnEvent
{
    public spawnEvent(Vector2 pos,GameObject go)
    {
        this.pos = pos;
        this.go = go;
    }

    public Vector2 pos;
    public GameObject go;
}