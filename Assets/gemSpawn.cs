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
                        int c = board.container.getcell(x, y);
                        if (c != -1)
                            spawnAt(new Vector2(x, y), c, true);
                    }
                }
    }

    public boardShape spawner;

    public List<boardGemObject> gems;
    public List<boardGemObject> gemsSpawn;

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
                                    int rand = Random.Range(0, gems.Count);

                                    c = rand;
                                    spawnAt(new Vector2(x, y), c, false);
                                }
                            }
                        }
            }
    }
    void spawnAt(Vector2 pos, int id, bool init)
    {
        GameObject go;
        if (init)
            go = GameObject.Instantiate(this.gems[id].prefab);
        else
            go = GameObject.Instantiate(this.gemsSpawn[id].prefab);

        go.transform.position = transform.position + new Vector3(pos.x, pos.y, -1);
        go.transform.parent = gemContainer.transform;

        board.container.setcell((int)pos.x, (int)pos.y, id);
        board.gocontainer.setcell((int)pos.x, (int)pos.y, go);

        this.gameObject.SendMessage("spawn", new spawnEvent(pos, go), SendMessageOptions.DontRequireReceiver);
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