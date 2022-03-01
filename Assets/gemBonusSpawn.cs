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

    void OnBonus(onBonus e)
    {
        if (e.id < spawn.gems.Count && e.id >= 0)
        {
            boardGemObject gem = spawn.gems[e.id];
            int idBonus = -1;
            int i = 0;
            while (i < gem.bonusList.Length && idBonus == -1)
            {
                if (gem.bonusList[i].type == e.mode)
                    if (gem.bonusList[i].minval <= e.val)
                        idBonus = i;

                i++;
            }

            if (idBonus != -1)
                spawnAt(e.pos, e.id, idBonus);
        }
    }

    void spawnAt(Vector2 pos, int id, int idBonus)
    {
        GameObject go = GameObject.Instantiate(spawn.gems[id].bonusList[idBonus].prefab);

        go.transform.position = transform.position + new Vector3(pos.x, pos.y, -1);
        go.transform.parent = spawn.Container.transform;

        go.AddComponent<m3BonusBreak>();
        go.GetComponent<m3BonusBreak>().type = idBonus;

        board.container.setcell(pos, id);
        board.gocontainer.setcell(pos, go);

        this.gameObject.SendMessage("spawn", new spawnEvent(pos, go), SendMessageOptions.DontRequireReceiver);
    }
}
