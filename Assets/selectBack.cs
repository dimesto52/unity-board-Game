using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectBack : MonoBehaviour
{
    public Cell cell
    {
        get
        {
            return this.GetComponent<cellLink>().cell;
        }
    }
    public SpriteRenderer render
    {
        get
        {
            return this.GetComponent<SpriteRenderer>();
        }
    }

    public Sprite selectedSprite;
    public Sprite baseSprite;

    // Start is called before the first frame update
    void Start()
    {
        render.sprite = baseSprite;

    }

    // Update is called once per frame
    void Update()
    {
        if(actionM3Click.first == cell || actionM3Click.second == cell)
        {
            render.sprite = selectedSprite;
        }
        else
        {
            render.sprite = baseSprite;
        }
    }
}
