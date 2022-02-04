using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BoardData : BoardData
{


    public GameObject particul;
    public GameObject soundbreak;
    public GameObject soundpop;

    int indexGem = 0;

    new void Start()
    {
        base.Start();

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Cell c = getCell(x, y);
                c.container = new breakCellContainer();
                c.Actions.Add("click", new actionM3Click());
                c.Actions["click"].cell = c;
                c.Actions.Add("Fall", new actionFall());
                c.Actions["Fall"].cell = c;

                int randid = Random.Range(0, base.prefabCellContain.Length);

                c.container.Set_idObj(randid);
                c.position = transform.position + Vector3.up * (y - height / 2.0f) + Vector3.right * (x - width / 2.0f);


                GameObject go = gemCreator(randid, c);

                c.gameObject = go;

            }
    }

    public float timeLeft = 0;
    public float speedStep = 2.0f;
    public float waitStep = 0.05f;

    void Update()
    {
        timeLeft += Time.deltaTime * speedStep;

        if (timeLeft >= 1.0f + waitStep)
        {
            timeLeft -= 1.0f + waitStep;

            foreach (Cell c in cells)
            {
                ((actionFall)c.Actions["Fall"]).Update();
            }
        }

        foreach (Cell c in cells)
        {
            c.debug();
        }
    }

    GameObject gemCreator(int id, Cell c)
    {
        GameObject go = GameObject.Instantiate(base.prefabCellContain[id]);
        go.transform.position = c.position;

        if (go.GetComponent<cellLink>() == null)
            go.AddComponent<cellLink>();

        go.GetComponent<cellLink>().cell = c;

        if (go.GetComponent<m3CellClick>() == null)
            go.AddComponent<m3CellClick>();   

        if (go.GetComponent<moveCell>() == null)
            go.AddComponent<moveCell>();

        go.GetComponent<moveCell>().speed = speedStep;

        if (go.GetComponent<onBreakPrefab>() == null)
            go.AddComponent<onBreakPrefab>();
        go.GetComponent<onBreakPrefab>().particul = particul;
        go.GetComponent<onBreakPrefab>().sound = soundbreak;

        if (go.GetComponent<increaseInStart>() == null)
            go.AddComponent<increaseInStart>();

        go.name = "gem" + indexGem;
        indexGem++;

        return go;
    }
}
