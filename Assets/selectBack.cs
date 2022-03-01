using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectBack : MonoBehaviour
{
    public Vector2 pos;
    public gemsSwap swap;
    

    public Sprite selectedSprite;
    public Sprite baseSprite;

    public SpriteRenderer render
    {
        get
        {
            return this.GetComponent<SpriteRenderer>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        render.sprite = baseSprite;

    }

    // Update is called once per frame
    void Update()
    {
        if(
            (swap.first.pos == pos && (swap.mode == swapMode.firstSelect || swap.mode == swapMode.secondSelect))||
            (swap.second.pos == pos && (swap.mode == swapMode.secondSelect))
            )
        {
            render.sprite = selectedSprite;
        }
        else
        {
            render.sprite = baseSprite;
        }
    }
}
