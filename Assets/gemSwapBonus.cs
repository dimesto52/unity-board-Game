using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemSwapBonus : MonoBehaviour
{

    BoardData board
    {
        get
        {
            return this.GetComponent<BoardData>();
        }
    }

    swapMode mode;

    public gemsSwapingBonus first;
    public gemsSwapingBonus second;
    public List<gemsMix> mix = new List<gemsMix>();

    public void onSwapSelect(swapSelect e)
    {
        if (mode == swapMode.noSelect)
        {
            first.go = e.gameObject;
            first.pos = e.pos;

            cellLinkBonus bonusLink = first.go.GetComponent<cellLinkBonus>();
            if (bonusLink != null)
                first.BonusId = bonusLink.value;

            mode = e.mode;
        }
        else if (mode == swapMode.firstSelect)
        {

            second.go = e.gameObject;
            second.pos = e.pos;

            cellLinkBonus bonusLink = second.go.GetComponent<cellLinkBonus>();
            if (bonusLink != null)
                second.BonusId = bonusLink.value;

            testSwap();

        }
    }

    public void resetSwap()
    {
        mode = swapMode.noSelect;
        first.go = null;
        first.pos = Vector2.zero;
        first.BonusId = -1;
        second.go = null;
        second.pos = Vector2.zero;
        second.BonusId = -1;
    }

    public void testSwap()
    {
        if ((first.BonusId != -1) && (second.BonusId != -1))
        {
            int idreact = 0;
            while (idreact < mix.Count)
            {
                if (
                    ((mix[idreact].GemsBonusId1 == first.BonusId) && (mix[idreact].GemsBonusId2 == second.BonusId)) ||
                    ((mix[idreact].GemsBonusId1 == second.BonusId) && (mix[idreact].GemsBonusId2 == first.BonusId))
                    )
                {
                    MixSwap(idreact);
                    this.gameObject.SendMessage("resetSwap", SendMessageOptions.DontRequireReceiver);
                    break;
                }
                else idreact++;
            }
        }
    }
    public void MixSwap(int idreact)
    {
        
        board.container.setcell(first.pos, -1);
        board.container.setcell(second.pos, -1);

        board.gocontainer.setcell(first.pos, null);
        board.gocontainer.setcell(second.pos, null);


        GameObject go = GameObject.Instantiate(mix[idreact].result);
        go.transform.position = first.go.transform.position;



        cellLink Link = go.AddComponent<cellLink>();
        cellLinkBonus bonusLink = go.AddComponent<cellLinkBonus>();
        go.AddComponent<actvateOnload>();

        Link.board = this.GetComponent<BoardData>();
        Link.pos = first.pos;
        bonusLink.value = idreact;

        GameObject.Destroy(first.go);
        GameObject.Destroy(second.go);

    }
}
[System.Serializable]
public class gemsSwapingBonus
{
    public GameObject go;
    public Vector2 pos;
    public int BonusId;

}

[System.Serializable]
public class gemsMix
{
    public int GemsBonusId1 = -1;
    public int GemsBonusId2 = -1;

    public GameObject result;
}
