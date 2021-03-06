using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m3BoardData : BoardData
{
   
    public Sprite selectedSprite;
    public Sprite baseSprite;

    public GameObject particul;
    public GameObject soundbreak;
    public GameObject soundpop;

    int indexGem = 0;


    public bonusContain[] prefabBonusContain;


    private GameObject backContainer;
    private GameObject gemsContainer;


    public static int allowTurn = 10;

    new void Start()
    {
        this.generate();

        if (backContainer == null) generateBrefab();

    }
    public void generateBrefab()
    {

        backContainer = new GameObject();
        backContainer.name = "backContainer";
        backContainer.transform.position = transform.position;
        backContainer.transform.parent = transform;

        gemsContainer = new GameObject();
        gemsContainer.name = "gemsContainer";
        gemsContainer.transform.position = transform.position;
        gemsContainer.transform.parent = transform;

        /*
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {

                Cell c = getCell(x, y);

                int[] validid = gemValid(c);
                int rand = Random.Range(0, validid.Length);
                int randid = validid[rand];

                GameObject go = gemCreator(randid, c);
                c.container.Set_idObj(randid);

                c.gameObject = go;

                GameObject goBack = new GameObject();
                goBack.name = "back" + "(" + x + ";" + y + ")";
                goBack.transform.position = c.position - Vector3.back;

                goBack.AddComponent<SpriteRenderer>();
                goBack.AddComponent<cellLink>();
                goBack.GetComponent<cellLink>().cell = c;
                goBack.AddComponent<selectBack>();
                goBack.GetComponent<selectBack>().selectedSprite = selectedSprite;
                goBack.GetComponent<selectBack>().baseSprite = baseSprite;

                goBack.transform.parent = backContainer.transform;
            }*/
    }
    public new void generate()
    {

        //if (cells.Length == 0)
            base.generate();
        /*
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Cell c = getCell(x, y);
                c.container = new breakCellContainer();
                c.container.Set_idObj(-1);
                if(!c.Actions.ContainsKey("click"))
                c.Actions.Add("click", new actionM3Click());
                c.Actions["click"].cell = c;
                if (!c.Actions.ContainsKey("Fall"))
                    c.Actions.Add("Fall", new actionFall());
                c.Actions["Fall"].cell = c;
                if (!c.Actions.ContainsKey("kill"))
                    c.Actions.Add("kill", new actionM3Kill());
                c.Actions["kill"].cell = c;

                c.position = transform.position + Vector3.up * (y - (height - 1) / 2.0f) + Vector3.right * (x - (width - 1) / 2.0f);
                
                getCell(x, y).board = this;
            }*/
    }

    public float timeLeft = 0;
    public float speedStep = 2.0f;
    public float waitStep = 0.05f;

    void Update()
    {
        timeLeft += Time.deltaTime * speedStep;

        if (allowTurn > 0)
            if (timeLeft >= 1.0f + waitStep)
            {
                timeLeft -= 1.0f + waitStep;
                /*
                foreach (Cell c in cells)
                {
                    if(c.Actions.ContainsKey("Fall"))
                        ((actionFall)c.Actions["Fall"]).Update();
                }
                
                for (int x = 0; x < width; x++)
                {
                    int y = this.height - 1;
                    Cell c = base.getCell(x,y);
                    if (c.container.Get_idObj() == -1)
                    {

                        GameObject.Instantiate(soundpop, c.position, Quaternion.identity);


                        int[] validid = gemValid(c);
                        int rand = Random.Range(0, validid.Length);

                        int randid = validid[rand];
                        c.container.Set_idObj(randid);

                        GameObject go = gemCreator(randid, c);

                        go.transform.position += Vector3.up;

                        c.gameObject = go;

                    }
                }*/
            }
    }

    GameObject gemCreator(int id, Cell c)
    {
        GameObject go = null;
        /*
        go = GameObject.Instantiate(base.prefabCellContain[id]);
        go.transform.position = c.position;

        if (go.GetComponent<cellLink>() == null)
            go.AddComponent<cellLink>();

        go.GetComponent<cellLink>().cell = c;

        if (go.GetComponent<m3CellClick>() == null)
            go.AddComponent<m3CellClick>();

        if (go.GetComponent<moveCell>() == null)
            go.AddComponent<moveCell>();
        if (go.GetComponent<m3UpdateEndMove>() == null)
            go.AddComponent<m3UpdateEndMove>();

        go.GetComponent<moveCell>().speed = speedStep;

        if (go.GetComponent<onBreakPrefab>() == null)
            go.AddComponent<onBreakPrefab>();
        go.GetComponent<onBreakPrefab>().particul = particul;
        go.GetComponent<onBreakPrefab>().sound = soundbreak;

        if (go.GetComponent<increaseInStart>() == null)
            go.AddComponent<increaseInStart>();

        go.name = "gem" + indexGem;
        go.transform.parent = gemsContainer.transform;
        indexGem++;
        */
        return go;
    }
    public GameObject spawnBonus(int id, Cell c , int type)
    {
        if (type >= prefabBonusContain.Length)
            type = prefabBonusContain.Length - 1;
        if (type < 0)
            type = 0;
        if (id >= prefabBonusContain[type].prefab.Length)
            id = prefabBonusContain[type].prefab.Length - 1;
        if (id < 0)
            id = 0;


        GameObject go = GameObject.Instantiate(prefabBonusContain[type].prefab[id]);
        go.transform.position = c.position;

        if (go.GetComponent<cellLink>() == null)
            go.AddComponent<cellLink>();

        //go.GetComponent<cellLink>().cell = c;

        if (go.GetComponent<m3CellClick>() == null)
            go.AddComponent<m3CellClick>();

        if (go.GetComponent<moveCell>() == null)
            go.AddComponent<moveCell>();
        if (go.GetComponent<m3UpdateEndMove>() == null)
            go.AddComponent<m3UpdateEndMove>();

        go.GetComponent<moveCell>().speed = speedStep;

        if (go.GetComponent<m3BonusBreak>() == null)
            go.AddComponent<m3BonusBreak>();
        //go.GetComponent<m3BonusBreak>().particul = particul;
        //go.GetComponent<m3BonusBreak>().sound = soundbreak;
        //go.GetComponent<m3BonusBreak>().type = type;

        if (go.GetComponent<increaseInStart>() == null)
            go.AddComponent<increaseInStart>();

        go.name = "gemBonus" + indexGem;
        go.transform.parent = gemsContainer.transform;
        indexGem++;
        
        c.gameObject = go;
        c.container.Set_idObj(id);

        return go;
    }
    int[] gemValid(Cell c)
    {
        List<int> valid = new List<int>();

        //Cell lastcell = ((actionFall)c.Actions["Fall"]).lastEmpty();

        /*
        for(int i = 0; i < base.prefabCellContain.Length; i++)
        {
            if (check(i, c))
                valid.Add(i);
        }
        */

        return valid.ToArray();
    }
    public bool check(int i, Cell c)
    {
        return (check_vertical(i, c) && check_horizontal(i, c));
    }
    public bool check_vertical(int i, Cell c)
    {
        int l1 = -2;
        int l2 = -2;
        int r1 = -2;
        int r2 = -2;
        if (c.left != null)
        {
            l1 = c.left.container.Get_idObj();
            if (c.left.left != null) l2 = c.left.left.container.Get_idObj();
        }
        if (c.right != null)
        {
            r1 = c.right.container.Get_idObj();
            if (c.right.right != null) r2 = c.right.right.container.Get_idObj();
        }

        if (l1 == i)
        {
            if (r1 == l1)
            {
                return false;
            }
            else if (l2 == l1)
            {
                return false;
            }
        }
        else if (r1 == i)
        {
            if (r2 == r1)
            {
                return false;
            }
        }
        return true;
    }

    public bool check_horizontal(int i, Cell c)
    {
        int d1 = -2;
        int d2 = -2;
        int u1 = -2;
        int u2 = -2;
        if (c.down != null)
        {
            d1 = c.down.container.Get_idObj();
            if (c.down.down != null) d2 = c.down.down.container.Get_idObj();
        }
        if (c.up != null)
        {
            u1 = c.up.container.Get_idObj();
            if (c.up.up != null) u2 = c.up.up.container.Get_idObj();
        }

        if (d1 == i)
        {
            if (u1 == d1)
            {
                return false;
            }
            else if (d2 == d1)
            {
                return false;
            }
        }
        else if (u1 == i)
        {
            if (u2 == u1)
            {
                return false;
            }
        }
        return true;
    }
}

[System.Serializable]
public class bonusContain
{
    public GameObject[] prefab;
}