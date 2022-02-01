using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakBoardData : BoardData
{
    // Start is called before the first frame update


    public GameObject particul;
    public GameObject soundbreak;
    public GameObject soundpop;

    new void Start()
    {
        base.Start();

        int index = 0;

        foreach (Cell c in base.cells)
        {
            c.container = new breakCellContainer();
            c.Actions.Add("click", new actionBreakClick());
            c.Actions["click"].cell = c;
            c.Actions.Add("Fall", new actionFall());
            c.Actions["Fall"].cell = c;

            int randid = Random.Range(0, base.prefabCellContain.Length);

            c.container.Set_idObj(randid);

            int row = index / height;
            int col = index % height;

            GameObject go = GameObject.Instantiate(base.prefabCellContain[randid]);
            go.transform.position = transform.position + Vector3.up * (row - height / 2.0f) + Vector3.right * (col - width / 2.0f);

            if (go.GetComponent<cellClick>() == null)
                go.AddComponent<cellClick>();
            
            go.GetComponent<cellClick>().cell = c;

            if (go.GetComponent<moveCell>() == null)
                go.AddComponent<moveCell>();

            go.GetComponent<moveCell>().cell = c;
            go.GetComponent<moveCell>().speed = speedStep;

            if (go.GetComponent<onBreakPrefab>() == null)
                go.AddComponent<onBreakPrefab>();
            go.GetComponent<onBreakPrefab>().particul = particul;
            go.GetComponent<onBreakPrefab>().sound = soundbreak;

            c.position = transform.position + Vector3.up * (row - height / 2.0f) + Vector3.right * (col - width / 2.0f);

            c.gameObject = go;
            go.name = "gem" + index;


           index++;
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

            for (int x = 0; x < width; x++)
            {
                int y = this.height - 1;
                Cell c = cells[x + y * width];
                if (c.container.Get_idObj() == -1)
                {

                    GameObject.Instantiate(soundpop, c.position,Quaternion.identity);


                    int randid = Random.Range(0, base.prefabCellContain.Length);
                    c.container.Set_idObj(randid);

                    GameObject go = GameObject.Instantiate(base.prefabCellContain[randid]);
                    go.transform.position = c.position + Vector3.up;

                    if (go.GetComponent<cellClick>() == null)
                        go.AddComponent<cellClick>();
                    go.GetComponent<cellClick>().cell = c;

                    if (go.GetComponent<moveCell>() == null)
                        go.AddComponent<moveCell>();
                    go.GetComponent<moveCell>().cell = c;

                    if (go.GetComponent<onBreakPrefab>() == null)
                        go.AddComponent<onBreakPrefab>();
                    go.GetComponent<onBreakPrefab>().particul = particul;
                    go.GetComponent<onBreakPrefab>().sound = soundbreak;

                    if (go.GetComponent<increaseInStart>() == null)
                        go.AddComponent<increaseInStart>();

                    c.gameObject = go;

                }
            }
        }


        foreach (Cell c in cells)
        {
            c.debug();
        }
    }
}
