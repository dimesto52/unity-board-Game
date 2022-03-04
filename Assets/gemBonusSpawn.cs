using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemBonusSpawn : MonoBehaviour
{

    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }

    gemSpawn spawn
    {
        get
        {
            return this.GetComponent<gemSpawn>();
        }
    }

    public List<BonusSpawnDescripion> paterns = new List<BonusSpawnDescripion>();
    public List<Vector2> posNewBonus = new List<Vector2>();
    public List<int> idNewBonus = new List<int>();

    void OnBonus(onBonus e)
    {
        int idBonus = -1;
        int i = 0;
        while (i < paterns.Count && idBonus == -1)
        {
            if (e.id == paterns[i].id)
                if (paterns[i].patern.eval(board, e.pos,e.id))
                {
                    idBonus = i;
                }
            i++;
        }

        if (idBonus != -1)
        {
            posNewBonus.Add(e.pos);
            idNewBonus.Add(idBonus);
            board.gocontainer.getcell(e.pos).GetComponent<onBreakPrefab>().sendBreak = true;
        }
    }
    void isBreak(Vector2 pos)
    {
        int index = posNewBonus.LastIndexOf(pos);
        int idBonus = idNewBonus[index];

        if (idBonus != -1)
            spawnAt(pos, idBonus);

        posNewBonus.RemoveAt(index);
        idNewBonus.RemoveAt(index);

    }

    void spawnAt(Vector2 pos, int idBonus)
    {
        BonusSpawnDescripion bonus = paterns[idBonus];

        GameObject go = GameObject.Instantiate(bonus.bonusPrefab);

        go.transform.position = transform.position + new Vector3(pos.x, pos.y, -1);
        go.transform.parent = spawn.Container.transform;

        board.container.setcell(pos, bonus.id);
        board.gocontainer.setcell(pos, go);

        this.gameObject.SendMessage("spawn", new spawnEvent(pos, go), SendMessageOptions.DontRequireReceiver);
    }
}
[System.Serializable]
public class BonusSpawnDescripion
{
    public GameObject bonusPrefab;
    public gemPatern patern;
    public int id = -1;
}
public class OnReadyBonus
{
    public int idBonus;
    public Vector2 pos;
}
