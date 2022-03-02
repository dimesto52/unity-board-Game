using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardData))]
public class backSpawn : MonoBehaviour
{
    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }
    
    public Sprite baseSprite;

    GameObject backContainer;

    // Start is called before the first frame update
    void Start()
    {

        backContainer = new GameObject();
        backContainer.name = "backContainer";
        backContainer.transform.position = transform.position;
        backContainer.transform.parent = transform;

        if (board.obj != null)
            if (board.obj.rows != null)
                foreach (int x in board.obj.rowsIndex)
                {
                    int indexX = board.obj.rowsIndex.IndexOf(x);
                    foreach (int y in board.obj.rows[indexX].cols)
                    {
                        GameObject goBack = new GameObject();

                        goBack.transform.position = transform.position + new Vector3(x, y, 0);
                        goBack.transform.parent = backContainer.transform;

                        goBack.name = "back" + "(" + x + ";" + y + ")";

                        goBack.AddComponent<SpriteRenderer>();
                        goBack.GetComponent<SpriteRenderer>().sprite = baseSprite;

                        this.gameObject.SendMessage("spawnBack", new spawnBackEvent(new Vector2(x, y), goBack), SendMessageOptions.DontRequireReceiver);
                    }
                }
    }
}

public class spawnBackEvent
{
    public spawnBackEvent(Vector2 pos, GameObject go)
    {
        this.pos = pos;
        this.go = go;
    }

    public Vector2 pos;
    public GameObject go;
}